using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class StringListElement
	{
		private const string LIST_PROPERTY = "list";
		
		private readonly SerializedProperty listProperty;
		
		private Vector2 scrollPosition = Vector2.zero;

		public StringListElement(List<string> list)
		{
			var listHolder = ScriptableObject.CreateInstance<StringListHolder>();
			listHolder.list = list;
			var serializedObject = new SerializedObject(listHolder);
			listProperty = serializedObject.FindProperty(LIST_PROPERTY);
		}
		
		public void Draw()
		{
			scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
			EditorGUILayout.PropertyField(listProperty, true);
			EditorGUILayout.EndScrollView();
		}
	}
}