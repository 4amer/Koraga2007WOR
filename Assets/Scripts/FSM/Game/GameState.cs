using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FMS.Game
{
    public abstract class GameState
    {
        protected readonly GameStateMachine Gsm;

        protected PlayerInput PlayerInput = null;

        public GameState(GameStateMachine gsm, PlayerInput playerInput)
        {
            Gsm = gsm;
            PlayerInput = playerInput;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}
