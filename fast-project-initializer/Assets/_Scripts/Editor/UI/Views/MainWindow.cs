using PushForce.FastProjectInitializer.Installers;
using PushForce.FastProjectInitializer.Keys;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace PushForce.FastProjectInitializer.UI
{
	public class MainWindow : ZenjectEditorWindow
	{
		[Inject]
		private ToolbarPanel toolbarPanel;
		
		public override void InstallBindings()
		{
			DirectoryCreatorInstaller.Install(Container);
			DirectoryInitializerViewInstaller.Install(Container);
			HierarchyInitializerViewInstaller.Install(Container);
			MainToolbarPanelInstaller.Install(Container);
			Container.Inject(this);
		}
		
		[MenuItem("Window/PushForce/FastProjectInitializer")]
		public static void OpenWindow()
		{
			var window = GetWindow<MainWindow>();
			window.titleContent = new GUIContent(TextConst.TITLE);
			window.Show();
		}

		public override void OnGUI()
		{
			base.OnGUI();
			toolbarPanel.DrawGUI();
			toolbarPanel.CurrentView.DrawGUI();
		}
	}
}
