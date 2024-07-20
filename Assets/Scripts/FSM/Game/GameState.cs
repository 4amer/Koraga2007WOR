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
        protected PlayerInput PlayerInput = null;
        protected IViewManager ViewManager = null;

        public GameState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager)
        {
            Gsm = gsm;
            PlayerInput = playerInput;
            ViewManager = viewManager;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
