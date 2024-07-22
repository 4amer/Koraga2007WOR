using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class DialogueState : GameState
    {
        public DialogueState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm, playerInput, viewManager)
        {

        }

        public override void Enter()
        {
            var inputActionMap = PlayerInput.actions.FindActionMap("Dialogue");
            if (inputActionMap.enabled == false)
            {
                inputActionMap.Enable();
            }
            PlayerInput.SwitchCurrentActionMap("Dialogue");
            ViewManager.ShowView(WindowTypes.DialogueView);
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public void SetToCutsceneState()
        {
            Gsm.SetState<CutsceneState>();
        }

        public override void Exit()
        {
            var inputActionMap = PlayerInput.actions.FindActionMap("Dialogue");
            if (inputActionMap.enabled == true)
            {
                inputActionMap.Disable();
            }
            ViewManager.HideView(WindowTypes.DialogueView);
        }
    }
}