using PushForce.FastProjectInitializer.Installers;
using PushForce.FastProjectInitializer.Keys;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace PushForce.FastProjectInitializer.UI
{
	public class MainWindow : ZenjectEditorWindow
	{
		private const float MIN_WINDOW_SIZE = 300;
		
		[Inject]
		private ToolbarPanel toolbarPanel;
		
		private Vector2 scrollPosition;
		
		public override void InstallBindings()
		{
			DirectoryCreatorInstaller.Install(Container);
			DirectoryInitializerViewInstaller.Install(Container);
			HierarchyInitializerViewInstaller.Install(Container);
			MainToolbarPanelInstaller.Install(Container);
			Container.Inject(this);
		}
		
		[MenuItem("PushForce/Windows/Fast Project Initializer")]
		public static void OpenWindow()
		{
			var window = GetWindow<MainWindow>();
			window.titleContent = new GUIContent(TextConst.TITLE);
			window.minSize = new Vector2(MIN_WINDOW_SIZE, MIN_WINDOW_SIZE);
			window.Show();
		}

		public override void OnGUI()
		{
			base.OnGUI();
			scrollPosition = GUILayout.BeginScrollView(scrollPosition);
			toolbarPanel.DrawGUI();
			toolbarPanel.CurrentView.DrawGUI();
			GUILayout.EndScrollView();
		}
	}
}
