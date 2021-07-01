using System;
using System.Collections.Generic;
using UnityEngine;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	[Serializable]
	public class DirectoryCreatorSettings
	{
		public string prefix = "ExamplePrefix";
		public string suffix = "ExampleSuffix";
		[Space, TextArea]
		public string readMeFileContent = "***********************************************************\n" +
		                                  "Delete this file after placing some files in this directory\n" +
		                                  "***********************************************************";
		[Space]
		public List<string>	directoriesToCreate;
	}
}