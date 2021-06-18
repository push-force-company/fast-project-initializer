using UnityEngine;
using Zenject;

namespace PushForce.FastProjectInitializer.DirectoryInitialization
{
	[CreateAssetMenu(menuName = "Settings/DirectoryCreatorSettings/New Settings")]
	public class DirectoryCreatorSettingsInstaller : ScriptableObjectInstaller<DirectoryCreatorSettingsInstaller>
	{
		public DirectoryCreatorSettings settings;

		public override void InstallBindings()
		{
			Container.BindInstance(settings);
		}
	}
}