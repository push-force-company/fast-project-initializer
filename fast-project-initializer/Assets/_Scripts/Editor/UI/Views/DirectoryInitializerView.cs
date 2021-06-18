using PushForce.FastProjectInitializer.DirectoryInitialization;
using PushForce.FastProjectInitializer.Keys;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		private readonly IDirectoryCreator directoryCreator;
		private readonly DirectoryCreatorSettings settings;
		private readonly StringListElement directoriesToCreate;
		
		protected DirectoryInitializerView(IDirectoryCreator directoryCreator, DirectoryCreatorSettings settings)
		{
			this.directoryCreator = directoryCreator;
			this.settings = settings;
			directoriesToCreate = new StringListElement(directoryCreator.DirectoriesToCreate);
		}
		
		public void DrawGUI()
		{
			InfoBox.Draw(TextConst.FUNCTIONALITY_INFO);
			DrawParametersBoxGroup();
			DrawSettingsBoxGroup();
			if (GUILayout.Button(TextConst.BUTTON_PROCEED))
			{
				directoryCreator.CreateDirectories();
			}
		}
		
		private void DrawParametersBoxGroup()
		{
			BoxGroup.Begin(TextConst.PARAMETERS);
				GUILayout.BeginHorizontal();
					GUILayout.Label(TextConst.PREFIX, GUILayout.MaxWidth(200));
					directoryCreator.Prefix = GUILayout.TextField(directoryCreator.Prefix).Trim();
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
					GUILayout.Label(TextConst.SUFFIX, GUILayout.MaxWidth(200));
					directoryCreator.Suffix = GUILayout.TextField(directoryCreator.Suffix).Trim();
				GUILayout.EndHorizontal();
			BoxGroup.End();
		}
		
		private void DrawSettingsBoxGroup()
		{
			BoxGroup.Begin(TextConst.SETTINGS);
				InfoBox.Draw(TextConst.README_TEXT_INFO);
				directoryCreator.ReadMeFileContent = GUILayout.TextArea(directoryCreator.ReadMeFileContent);
				directoriesToCreate.Draw();
			BoxGroup.End();
		}
	}
}
