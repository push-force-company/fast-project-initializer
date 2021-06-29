using System.Collections.Generic;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	public interface IDirectoryCreator
	{
		public string Prefix { get; set; }
		public string Suffix { get; set; }
		public List<string> DirectoriesToCreate { get; set; }
		public string ReadMeFileContent { get; set; }
		void CreateDirectories();
	}
}