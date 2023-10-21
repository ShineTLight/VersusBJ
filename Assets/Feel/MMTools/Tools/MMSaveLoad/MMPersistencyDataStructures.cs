using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace MoreMountains.Tools
{
	/// <summary>
	/// A serializable class used to store scene data, the key is a string (the scene name), the value is a MMPersistencySceneData
	/// </summary>
	[Serializable]
	public class DictionaryStringSceneData : MMSerializableDictionary<string, MMPersistencySceneData>
	{
		public DictionaryStringSceneData() : base() { }
		protected DictionaryStringSceneData(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}

	/// <summary>
	/// A serializable class used to store object data, the key is a string (the object name), the value is a string (the object data)
	/// </summary>
	[Serializable]
	public class DictionaryStringString : MMSerializableDictionary<string, string>
	{
		public DictionaryStringString() : base() { }
		protected DictionaryStringString(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
	
	/// <summary>
	/// A serializable class used to store all the data for a persistency manager, a collection of scene datas
	/// </summary>
	[Serializable]
	public class MMPersistencyManagerData
	{
		public string PersistencyID;
		public string SaveDate;
		public DictionaryStringSceneData SceneDatas;
	}
	
	/// <summary>
	/// A serializable class used to store all the data for a scene, a collection of object datas
	/// </summary>
	[Serializable]
	public class MMPersistencySceneData
	{
		public DictionaryStringString ObjectDatas;
	}
	
	/// <summary>
	/// The various types of persistency events that can be triggered by the MMPersistencyManager
	/// </summary>
	public enum MMPersistencyEventType { DataSavedToMemory, DataLoadedFromMemory, DataSavedFromMemoryToFile, DataLoadedFromFileToMemory }

	/// <summary>
	/// A data structure used to store persistency event data.
	/// To use :
	/// MMPersistencyEvent.Trigger(MMPersistencyEventType.DataLoadedFromFileToMemory, "yourPersistencyID");
	/// </summary>
	public struct MMPersistencyEvent
	{
		public MMPersistencyEventType PersistencyEventType;
		public string PersistencyID;

		public MMPersistencyEvent(MMPersistencyEventType eventType, string persistencyID)
		{
			PersistencyEventType = eventType;
			PersistencyID = persistencyID;
		}

		static MMPersistencyEvent e;
		public static void Trigger(MMPersistencyEventType eventType, string persistencyID)
		{
			e.PersistencyEventType = eventType;
			e.PersistencyID = persistencyID;
		}
	}
}
