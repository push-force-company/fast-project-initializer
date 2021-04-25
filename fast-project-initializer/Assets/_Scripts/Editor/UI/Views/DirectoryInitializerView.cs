using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		private readonly string label;
		
		public DirectoryInitializerView(string label)
		{
			this.label = label;
		}
		
		public void DrawGUI()
		{
			GUILayout.Label(label);
			if (GUILayout.Button("Restart"))
			{
				Debug.Log("click");
			}
		}
	}
}