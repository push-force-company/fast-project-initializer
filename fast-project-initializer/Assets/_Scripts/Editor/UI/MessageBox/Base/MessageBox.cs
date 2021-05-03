using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class MessageBox
	{
		protected static void DrawBox(GUIContent icon, string text)
		{
			GUIStyle backgroundStyle = GetBackgroundStyle();
			GUIStyle iconStyle = GetIconStyle();
			GUIStyle labelStyle = GetLabelStyle();
			
			GUILayout.BeginHorizontal(backgroundStyle, GUILayout.Height(1));
				GUILayout.Box(icon, iconStyle, GUILayout.MaxWidth(50), GUILayout.ExpandHeight(true));
				GUILayout.Label(text, labelStyle, GUILayout.ExpandHeight(true));
			GUILayout.EndHorizontal();
		}
		
		private static GUIStyle GetBackgroundStyle()
		{
			GUIStyle backgroundStyle = new GUIStyle(GUI.skin.box);
			backgroundStyle.margin = new RectOffset(30, 30, 15, 15);
			backgroundStyle.padding = new RectOffset(10, 10, 10, 10);
			return backgroundStyle;
		}
		
		private static GUIStyle GetIconStyle()
		{
			GUIStyleState iconStyleState = new GUIStyleState();
			iconStyleState.textColor = Color.white;
			iconStyleState.background = Texture2D.blackTexture;
			GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
			boxStyle.alignment = TextAnchor.MiddleCenter;
			boxStyle.normal = iconStyleState;
			return boxStyle;
		}
		
		private static GUIStyle GetLabelStyle()
		{
			GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
			labelStyle.alignment = TextAnchor.MiddleLeft;
			labelStyle.wordWrap = true;
			return labelStyle;
		}
	}
}