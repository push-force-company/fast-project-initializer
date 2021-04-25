using PushForce.FastProjectInitializer.UI;
using Zenject;

namespace PushForce.FastProjectInitializer.Installers
{
	public class DirectoryInitializerViewInstaller : Installer<DirectoryInitializerViewInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IView>().To<DirectoryInitializerView>().AsSingle();
		}
	}
}