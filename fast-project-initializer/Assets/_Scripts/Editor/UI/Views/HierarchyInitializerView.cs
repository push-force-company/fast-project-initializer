using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class HierarchyInitializerView : IView
	{
		private const string LABEL = "Hierarchy Initialization";
		
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
