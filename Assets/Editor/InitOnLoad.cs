﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.Xml;

//! Handle the editor-on-load stuff and assets modifications.
[InitializeOnLoad]
public class InitOnLoad : UnityEditor.AssetModificationProcessor
{
#region Constants
	//! Temp file name for touching.
	private const string TEMP_FILE_NAME = "__he_editor_change";
#endregion
	

#region Operations
	//! Hande pre-save action.
	public static string[] OnWillSaveAssets(string[] Paths)
	{
		// Are we saving scene
		foreach (var item in Paths)
		{
			if (item.Contains(EditorApplication.currentScene))
			{
				// Try to serialize objects if there is serialization manager in
				// scene and we're saving the scene. Otherwise some recursive 
				// calls could be done if this serialization were at the
				// beginning of function, because AssetDatabase.CopyAsset() will
				// call this function again
				var serialization_manager = (SerializationManager)GameObject.FindObjectOfType(typeof(SerializationManager));
				if (serialization_manager)
				{
					serialization_manager.Serialize();
					// Set as dirty
					EditorUtility.SetDirty(serialization_manager);
				} 

				var level_manager = GameObject.Find("LevelManager").GetComponent<he.script.LevelManager>();
				if (level_manager != null)
				{
					string current_scene_path = item.Substring(0, item.LastIndexOf('/'));
					current_scene_path = current_scene_path.Substring(current_scene_path.LastIndexOf('/') + 1) + "/";

					level_manager.SaveScene(current_scene_path, new AssetDatabaseCustom());

					// Also save as xml

					// Generate path for xml
					string xml_save_path = item.Substring(0, item.LastIndexOf('.')) + ".xml";
					var xml_writer_settings = new XmlWriterSettings();
					xml_writer_settings.Encoding = Encoding.UTF8;
					xml_writer_settings.Indent = true;
					// If file exist, make backup; Don't want to use
					// AssetDatabase here because it complicates things a bit
					if (System.IO.File.Exists(xml_save_path))
						FileUtil.ReplaceFile(xml_save_path, xml_save_path + ".old");

					var xml_writer = XmlWriter.Create(xml_save_path, xml_writer_settings);
					// Start xml document
					xml_writer.WriteStartDocument();

					level_manager.SaveSceneXml(xml_writer, new AssetDatabaseCustom());
					
					xml_writer.WriteEndDocument();

					xml_writer.Flush();
					xml_writer.Close();
					break;
				}
			}
		}

		return Paths;
	}

	//! Handle the editor -> player change.
	public static void Change()
	{
		var serialization_manager = (SerializationManager)GameObject.FindObjectOfType(typeof(SerializationManager));

		// Editor -> Player
		if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
		{
			if (serialization_manager)
			{
				Debug.Log("Change in EDIT");
				serialization_manager.Serialize();
				// Touch file to signal we're going to player
				System.IO.File.Create(Application.temporaryCachePath + "/" + TEMP_FILE_NAME);
			}
		}
		// Player -> Editor
		else if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
		{
			if (serialization_manager)
			{
				// Remove file to signal we're going to editor
				System.IO.File.Delete(Application.temporaryCachePath + "/" + TEMP_FILE_NAME);
			}
		}
	}
#endregion

#region Construction
	static InitOnLoad()
	{
		Debug.Log("InitOnLoad loaded...");
		
		EditorApplication.playmodeStateChanged += Change;

		// If there is serialization manager in scene.
		var serialization_manager = (SerializationManager)GameObject.FindObjectOfType(typeof(SerializationManager));
		if (serialization_manager)
		{
			// InitOnLoad() is ran not only on editor startup but also if we're in
			// editor and some code needs to be reloaded. Therefor, all
			// components in editor are default-serialized by unity, without
			// executing our serialization code. We must the explicitly call
			// deserialization code.
			try
			{
				// Only if not in player, otherwise double deserialization occurs
				// (one here, another one in Awake() of serialization component)
				// Also reload the type infos here, because assemblies could be
				// changed here
				if (!System.IO.File.Exists(Application.temporaryCachePath + "/" + TEMP_FILE_NAME))
				{
					serialization_manager.Reload();
					serialization_manager.Deserialize();

					AssetDatabase.Refresh();
				}
			}
			catch (System.Exception e)
			{
				Debug.LogWarning("Exception while deserializing on init:" + e.ToString());
			}
		}
	}
#endregion
}
