using PushForce.FastProjectInitializer.Keys;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		public void DrawGUI()
		{
			InfoBox.Draw(TextConst.DIRECTORY_INITIALIZER_FUNCTIONALITY_INFO);
			if (GUILayout.Button("Proceed"))
			{
				Debug.Log("click");
			}
		}
	}
}