using System;
using System.IO;
using System.Security;
using ModestTree;
using PushForce.FastProjectInitializer.Keys;
using UnityEditor;
using UnityEngine;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	public class DirectoryCreator : IDirectoryCreator
	{
		private const string PATH_PREFIX = "Assets/";
		private const string README_FILE_NAME = "/readme.txt";
		
		private readonly DirectoryCreatorSettings settings;
		
		public DirectoryCreator(DirectoryCreatorSettings settings)
		{
			this.settings = settings;
		}
		
		public void CreateDirectories()
		{
			foreach (string directoryPath in settings.directoriesToCreate)
			{
				if(directoryPath.IsEmpty())
				{
					Debug.LogWarning(TextConst.WARNING_DIRECTORY_NAME_EMPTY);
					continue;
				}
				
				string path = PATH_PREFIX + settings.prefix + directoryPath + settings.suffix;
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
			CreateFileAtPathWithContent(path, settings.readMeFileContent);
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