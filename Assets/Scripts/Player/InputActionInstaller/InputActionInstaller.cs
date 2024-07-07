using JoystickSystem;
using Player.Ability;
using UnityEngine.InputSystem;
using Zenject;

public class InputActionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromComponentInHierarchy(this).AsSingle().NonLazy();
        Container.Bind<RightJoystick>().FromComponentInHierarchy(this).AsSingle().NonLazy();
        Container.Bind<LeftJoystick>().FromComponentInHierarchy(this).AsSingle().NonLazy();

        Container.Bind<IAbility>().To<RunAbility>().AsSingle().NonLazy();
        Container.Bind<IAbility>().To<DashAbility>().AsSingle().NonLazy();
    }
}
