using JoystickSystem;
using MobileInput;
using Player.Ability;
using UnityEngine.InputSystem;
using Zenject;

public class InputActionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<RightJoystick>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<LeftJoystick>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<IScreenButton>().To<ScreenButton>().FromComponentsInHierarchy().AsSingle().NonLazy();

        Container.Bind<IAbility>().To<RunAbility>().AsSingle().NonLazy();
        Container.Bind<IAbility>().To<DashAbility>().AsSingle().NonLazy();
    }
}
