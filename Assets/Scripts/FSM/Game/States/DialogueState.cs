using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FMS.Game
{
    public class DialogueState : GameState
    {
        public DialogueState(GameStateMachine gsm, PlayerInput playerInput) : base(gsm, playerInput)
        {

        }

        public override void Enter()
        {
            PlayerInput.actions.FindActionMap("Dialogue").Enable();
            PlayerInput.SwitchCurrentActionMap("Dialogue");
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public override void Exit()
        {
            PlayerInput.actions.FindActionMap("Dialogue").Disable();
        }
    }
}