using PushForce.FastProjectInitializer.UI;
using Zenject;

namespace PushForce.FastProjectInitializer.Installers
{
	public class MainToolbarPanelInstaller : Installer<MainToolbarPanelInstaller>
	{
		public override void InstallBindings()
		{
			string[] toolbarNames = {"Directory Initialization", "Hierarchy Initialization"};
			Container.BindInstance(toolbarNames).WhenInjectedInto<MainToolbarPanel>();
			Container.Bind<ToolbarPanel>().To<MainToolbarPanel>().AsSingle();
		}
	}
}