using SoundSystem;
using System.Collections;
using System.Collections.Generic;
using Zenject;

public class SoundInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISoundManager>().To<SoundManager>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
