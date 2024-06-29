using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FMS.Game
{
    public class PauseState : GameState
    {
        public PauseState(GameStateMachine gsm, PlayerInput playerInput) : base(gsm, playerInput)
        {

        }

        public override void Enter()
        {
            PlayerInput.SwitchCurrentActionMap("UI");
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }
    }
}