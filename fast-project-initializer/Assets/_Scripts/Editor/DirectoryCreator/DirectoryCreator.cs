using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using PushForce.FastProjectInitializer.Keys;
using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	public class DirectoryCreator : IDirectoryCreator
	{
		private const string PATH_PREFIX = "Assets/";
		private const string README_FILE_NAME = "/readme.txt";
		
		public string Prefix { get; set; }
		public string Suffix { get; set; }
		public List<string> DirectoriesToCreate { get; set; }
		public string ReadMeFileContent { get; set; }
		
		public DirectoryCreator()
		{
			Prefix = TextConst.EXAMPLE_PREFIX;
			Suffix = TextConst.EXAMPLE_SUFFIX;
			ReadMeFileContent = TextConst.EXAMPLE_README;
			DirectoriesToCreate = new List<string>();
		}
		
		public void CreateDirectories()
		{
			foreach (string directoryPath in DirectoriesToCreate)
			{
				string path = PATH_PREFIX + Prefix + directoryPath + Suffix;
				if(!Directory.Exists(path))
				{
					CreateDirectoryAtPath(path);
				}
				else
				{
					Debug.LogWarning(string.Format(TextConst.WARNING_DIRECTORY_ALREADY_EXISTS, path));
				}
			}
			AssetDatabase.Refresh();
		}
		
		private void CreateDirectoryAtPath(string path)
		{
			try
			{
				Directory.CreateDirectory(path);
				AssetDatabase.ImportAsset(path);
				CreateReadMeFile(path);
			}
			catch(PathTooLongException)
			{
				Debug.LogError(string.Format(TextConst.EXCEPTION_PATH_TO_LONG, path));
			}
			catch (IOException)
			{
				Debug.LogError(string.Format(TextConst.EXCEPTION_DIRECTORY_IO, path));
			}
			catch(UnauthorizedAccessException)
			{
				Debug.LogError(TextConst.EXCEPTION_FILE_UNAUTHORIZED_ACCESS);
			}
			catch(ArgumentNullException)
			{
				Debug.LogError(string.Format(TextConst.EXCEPTION_DIRECTORY_ARGUMENT, path));
			}
			catch(ArgumentException)
			{
				Debug.LogError(TextConst.EXCEPTION_DIRECTORY_ARGUMENT_NULL);
			}
			catch(Exception e)
			{
				Debug.LogError(e);
			}
		}
		
		private void CreateReadMeFile(string path)
		{
			path += README_FILE_NAME;
			CreateFileAtPathWithContent(path, ReadMeFileContent);
			AssetDatabase.ImportAsset(path);
		}
		
		private void CreateFileAtPathWithContent(string path, string content)
		{
			try
			{
				using var writer = new StreamWriter(path, false);
				writer.WriteLine(content);
				writer.Close();
			}
			catch(SecurityException)
			{
				Debug.LogError(TextConst.EXCEPTION_SECURITY);
			}
			catch(UnauthorizedAccessException)
			{
				Debug.LogError(TextConst.EXCEPTION_FILE_UNAUTHORIZED_ACCESS);
			}
			catch(PathTooLongException)
			{
				Debug.LogError(string.Format(TextConst.EXCEPTION_PATH_TO_LONG, path));
			}
			catch(IOException)
			{
				Debug.LogError(string.Format(TextConst.EXCEPTION_FILE_IO, path));
			}
			catch(Exception e)
			{
				Debug.LogError(e);
			}
		}
	}
}