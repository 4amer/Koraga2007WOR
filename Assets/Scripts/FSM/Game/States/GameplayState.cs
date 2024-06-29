using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FMS.Game
{
    public class GameplayState : GameState
    {
        public GameplayState(GameStateMachine gsm, PlayerInput playerInput) : base(gsm, playerInput)
        {

        }

        public override void Enter()
        {
            PlayerInput.actions.FindActionMap("GamePlay").Enable();
            PlayerInput.SwitchCurrentActionMap("GamePlay");
        }

        public void SetToDialogueState()
        {
            Gsm.SetState<DialogueState>();
        }

        public override void Exit()
        {
            PlayerInput.actions.FindActionMap("GamePlay").Disable();
        }
    }
}