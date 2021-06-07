using System.IO;
using PushForce.FastProjectInitializer.Keys;
using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	public class DirectoryCreator : IDirectoryCreator
	{
		private const string PATH_PREFIX = "Assets/";
		private const string README_FILE_NAME = "/readme.txt";
		
		public string[] DirectoriesToCreate { get; set; }
		public string ReadMeFileContent { get; set; }
		
		public void CreateDirectories()
		{
			foreach (string directoryPath in DirectoriesToCreate)
			{
				string path = PATH_PREFIX + directoryPath;
				if(!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
					AssetDatabase.ImportAsset(path);
					CreateReadMeFile(path);
				}
				else
				{
					Debug.LogWarning(string.Format(TextConst.WARNING_DIRECTORY_ALREADY_EXISTS, path));
				}
			}
			AssetDatabase.Refresh();
		}
		
		private void CreateReadMeFile(string path)
		{
			path += README_FILE_NAME;
			StreamWriter writer = new StreamWriter(path, false);
			writer.WriteLine(ReadMeFileContent);
			writer.Close();
			AssetDatabase.ImportAsset(path);
		}
	}
}