using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		public void drawGUI()
		{
			GUI.Label(new Rect(25, 75, 200, 50), "Test Label");
			if (GUI.Button(new Rect(25, 25, 200, 50), "Restart"))
			{
				Debug.Log("click");
			}
		}
	}
}