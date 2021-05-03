using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public abstract class ToolbarPanel
	{
		private readonly IView[] views;
		private readonly string[] toolbarNames;
		private int currentViewIndex;

		public IView CurrentView => views[currentViewIndex];
		
		protected ToolbarPanel(IView[] views, string[] toolbarNames)
		{
			this.views = views;
			this.toolbarNames = toolbarNames;
		}
		
		public void DrawGUI()
		{
			currentViewIndex = GUILayout.Toolbar(currentViewIndex, toolbarNames, GUILayout.Height(30));
		}
	}
}