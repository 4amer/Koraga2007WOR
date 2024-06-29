using FMS.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FSM
{
    public class FSMInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}