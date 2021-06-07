namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	public interface IDirectoryCreator
	{
		public string[] DirectoriesToCreate { set; }
		public string ReadMeFileContent { set; }
		void CreateDirectories();
	}
}