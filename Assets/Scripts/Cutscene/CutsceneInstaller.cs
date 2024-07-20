using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CutsceneSystem
{
    public class CutsceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICutsceneManager>().To<CutsceneManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<CutsceneTrigger>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}