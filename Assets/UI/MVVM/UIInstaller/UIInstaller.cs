using Zenject;

namespace UI
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IViewManager>().To<ViewManager>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<DialogueView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<DialogueModel>().AsSingle().NonLazy();
            Container.Bind<DialogueViewModel>().AsSingle().NonLazy();
        }
    }
}
