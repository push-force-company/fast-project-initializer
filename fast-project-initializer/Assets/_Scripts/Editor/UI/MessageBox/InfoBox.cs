using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class InfoBox : MessageBox
	{
		public static void Draw(string text)
		{
			GUIContent icon = new GUIContent(EditorGUIUtility.IconContent("d_console.infoicon.sml@2x"));
			DrawBox(icon, text);
		}
		
	}
}