using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public static class StringListElement
	{
		private const string LIST_PROPERTY = "list";
		
		public static List<string> Draw(List<string> list)
		{
			var listHolder = ScriptableObject.CreateInstance<StringListHolder>();
			listHolder.list = list;
			var serializedObject = new SerializedObject(listHolder);
			SerializedProperty serializedProperty = serializedObject.FindProperty(LIST_PROPERTY);
			EditorGUILayout.PropertyField(serializedProperty, true);
			return listHolder.list;
		}
	}
}