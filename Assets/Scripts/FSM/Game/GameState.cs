using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public abstract class GameState
    {
        protected readonly GameStateMachine Gsm;

        public GameState(GameStateMachine gsm)
        {
            Gsm = gsm;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
