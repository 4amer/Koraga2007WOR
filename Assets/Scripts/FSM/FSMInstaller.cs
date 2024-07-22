using FSM.Game;
using Zenject;

namespace FSM
{
    public class FSMInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameStateMachine>().AsSingle().NonLazy();

        }
    }
}