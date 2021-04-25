using PushForce.FastProjectInitializer.Installers;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace PushForce.FastProjectInitializer.UI
{
	public class MainWindow : ZenjectEditorWindow
	{
		[Inject]
		private readonly IView[] views;
		private readonly string[] toolbarNames = {"Directory Initialization", "Hierarchy Initialization"};
		private IToolbarPanel toolbarPanel;
		
		public override void InstallBindings()
		{
			DirectoryInitializerViewInstaller.Install(Container);
			HierarchyInitializerViewInstaller.Install(Container);
			Container.Inject(this);
			toolbarPanel = new ToolbarPanel(views, toolbarNames);
		}
		
		[MenuItem("Window/PushForce/FastProjectInitializer")]
		public static void OpenWindow()
		{
			var window = GetWindow<MainWindow>();
			window.titleContent = new GUIContent(TITLE);
			window.Show();
		}

		public override void OnGUI()
		{
			base.OnGUI();
			directoryInitializerView.drawGUI();
		}
	}
}
