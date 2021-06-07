using PushForce.FastProjectInitializer.DirectoryInitialization;
using PushForce.FastProjectInitializer.Keys;
using UnityEngine;

namespace PushForce.FastProjectInitializer.UI
{
	public class DirectoryInitializerView : IView
	{
		private readonly IDirectoryCreator directoryCreator;
		
		protected DirectoryInitializerView(IDirectoryCreator directoryCreator)
		{
			this.directoryCreator = directoryCreator;
		}
		
		public void DrawGUI()
		{
			InfoBox.Draw(TextConst.DIRECTORY_INITIALIZER_FUNCTIONALITY_INFO);
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