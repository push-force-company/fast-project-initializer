using PushForce.FastProjectInitializer.DirectoryInitialization;
using Zenject;

namespace PushForce.FastProjectInitializer.Installers
{
	public class DirectoryCreatorInstaller : Installer<DirectoryCreatorInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IDirectoryCreator>().To<DirectoryCreator>().AsSingle();
		}
	}
}