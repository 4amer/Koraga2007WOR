using FMS.Game;
using Zenject;

namespace DialogueSystem
{
    public class DialogueInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDialogueManager>().To<DialogueManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<DialogueTrigger>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}