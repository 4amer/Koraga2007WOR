using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class PauseState : GameState
    {
        public PauseState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm, playerInput, viewManager)
        {

        }

        public override void Enter()
        {
            PlayerInput.SwitchCurrentActionMap("UI");
            ViewManager.ShowView(WindowTypes.MenuView);
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public override void Exit()
        {
            ViewManager.HideView(WindowTypes.MenuView);
        }
    }
}