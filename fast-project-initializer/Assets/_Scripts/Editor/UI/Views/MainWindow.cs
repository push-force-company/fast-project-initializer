using UnityEditor;
using UnityEngine;
using Zenject;

namespace PushForce.FastProjectInitializer.UI
{
	public class MainWindow : ZenjectEditorWindow
	{
		private readonly IView directoryInitializerView = new DirectoryInitializerView();
		
		public override void InstallBindings()
		{}
		
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
