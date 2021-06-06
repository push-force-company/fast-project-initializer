using PushForce.FastProjectInitializer.DirectoryInitialization;
using PushForce.FastProjectInitializer.Keys;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		private readonly IDirectoryCreator directoryCreator;
		
		// TODO: to be removed
		string text = "**************************************\nDelete this file after placing some files in this directory\n**************************************";
		
		protected DirectoryInitializerView(IDirectoryCreator directoryCreator)
		{
			this.directoryCreator = directoryCreator;
		}
		
		public void DrawGUI()
		{
			InfoBox.Draw(TextConst.DIRECTORY_INITIALIZER_FUNCTIONALITY_INFO);
			
			// TODO: change this mess into a valid view implementation
			BoxGroup.Begin("Parameters");
				GUILayout.BeginHorizontal();
					GUILayout.Label("Prefix", GUILayout.MaxWidth(200));
					GUILayout.TextField("ExamplePrefix");
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
					GUILayout.Label("Suffix", GUILayout.MaxWidth(200));
					GUILayout.TextField("ExampleSuffix");
				GUILayout.EndHorizontal();
			BoxGroup.End();
			BoxGroup.Begin("Settings");
				InfoBox.Draw(TextConst.DIRECTORY_INITIALIZER_FUNCTIONALITY_INFO);
				text = GUILayout.TextArea(text);
				GUILayout.Toggle(false, "Clear up project");
			BoxGroup.End();
			
			if (GUILayout.Button("Proceed"))
			{
				directoryCreator.DirectoriesToCreate = new []{ "Dupa", "Dupa1", "Dupa2/Dupa" };
				directoryCreator.ReadMeFileContent = "************************************************************\n" +
				                                     "Delete this file after placing some files int this directory\n" +
				                                     "************************************************************";
				directoryCreator.CreateDirectories();
			}
		}
	}
}