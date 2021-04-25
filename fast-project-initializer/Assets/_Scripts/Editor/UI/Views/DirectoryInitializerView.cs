using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		private const string LABEL = "Directory Initialization";
		
		public void DrawGUI()
		{
			GUILayout.Label(LABEL);
			if (GUILayout.Button("Proceed"))
			{
				Debug.Log("click");
			}
		}
	}
}