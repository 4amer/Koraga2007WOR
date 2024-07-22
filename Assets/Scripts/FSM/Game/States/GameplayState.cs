using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class GameplayState : GameState
    {
        public GameplayState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm, playerInput, viewManager)
        {

        }

        public override void Enter()
        {
            ViewManager.ShowView(WindowTypes.GameView);
            ViewManager.ShowView(WindowTypes.MobileView);
            var gameplayActionMap = PlayerInput.actions.FindActionMap("GamePlay");
            var UIActionMap = PlayerInput.actions.FindActionMap("UI");
            gameplayActionMap.Enable();
            UIActionMap.Enable();
        }

        public void SetToDialogueState()
        {
            Gsm.SetState<DialogueState>();
        }

        public void SetToCutsceneState()
        {
            Gsm.SetState<CutsceneState>();
        }

        public override void Exit()
        {
            var gameplayActionMap = PlayerInput.actions.FindActionMap("GamePlay");
            gameplayActionMap.Disable();
            ViewManager.HideView(WindowTypes.GameView);
            ViewManager.HideView(WindowTypes.MobileView);
        }
    }
}