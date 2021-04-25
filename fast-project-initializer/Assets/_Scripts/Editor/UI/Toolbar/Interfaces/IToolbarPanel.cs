namespace PushForce.FastProjectInitializer.UI
{
	public interface IToolbarPanel : IView
	{
		IView CurrentView { get; }
	}
}