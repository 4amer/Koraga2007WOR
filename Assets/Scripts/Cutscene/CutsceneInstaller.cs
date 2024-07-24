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
            Container.BindInterfacesTo<CutsceneManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<CutsceneTrigger>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}