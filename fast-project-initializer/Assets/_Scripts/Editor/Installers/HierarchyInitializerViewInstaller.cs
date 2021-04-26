using PushForce.FastProjectInitializer.UI;
using Zenject;

namespace PushForce.FastProjectInitializer.Installers
{
	public class HierarchyInitializerViewInstaller : Installer<HierarchyInitializerViewInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IView>().To<HierarchyInitializerView>().AsSingle();
		}
	}
}