using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public static class BoxGroup
	{
		public static void Begin(string title)
		{
			GUIStyle backgroundStyle = GetBackgroundStyle();
			GUIStyle titleStyle = GetTitleStyle();
			GUIStyle contentStyle = GetContentStyle();
			
			GUILayout.BeginVertical(backgroundStyle, GUILayout.ExpandWidth(true));
			GUILayout.BeginVertical(titleStyle, GUILayout.ExpandWidth(true));
			GUILayout.Label(title);
			GUILayout.EndVertical();
			GUILayout.BeginVertical(contentStyle, GUILayout.ExpandWidth(true));
		}
		
		private static GUIStyle GetBackgroundStyle()
		{
			GUIStyle backgroundStyle = new GUIStyle(GUI.skin.box);
			backgroundStyle.margin = new RectOffset(30, 30, 15, 15);
			return backgroundStyle;
		}
		
		private static GUIStyle GetTitleStyle()
		{
			GUIStyleState titleStyleState = new GUIStyleState();
			titleStyleState.textColor = Color.white;
			titleStyleState.background = Texture2D.grayTexture;
			
			GUIStyle titleStyle = new GUIStyle(GUI.skin.box);
			titleStyle.margin = new RectOffset(0, 0, 0, 0);
			titleStyle.padding = new RectOffset(10, 10, 0, 0);
			titleStyle.normal = titleStyleState;
			return titleStyle;
		}
		
		private static GUIStyle GetContentStyle()
		{
			GUIStyle contentStyle = new GUIStyle(GUI.skin.box);
			contentStyle.margin = new RectOffset(0, 0, 0, 0);
			contentStyle.padding = new RectOffset(17, 17, 10, 10);
			return contentStyle;
		}
		
		public static void End()
		{
			GUILayout.EndVertical();
			GUILayout.EndVertical();
		}
	}
}