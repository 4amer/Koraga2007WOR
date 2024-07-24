using UI;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class GameplayState : GameState
    {
        private PlayerInput _playerInput = null;
        private IViewManager _viewManager = null;

        public GameplayState(GameStateMachine gsm, IViewManager viewManager, PlayerInput playerInput) : base(gsm)
        {
            _playerInput = playerInput;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            _viewManager.ShowView(WindowTypes.GameView);
            _viewManager.ShowView(WindowTypes.MobileView);
            var gameplayActionMap = _playerInput.actions.FindActionMap("GamePlay");
            var UIActionMap = _playerInput.actions.FindActionMap("UI");
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
            var gameplayActionMap = _playerInput.actions.FindActionMap("GamePlay");
            gameplayActionMap.Disable();
            _viewManager.HideView(WindowTypes.GameView);
            _viewManager.HideView(WindowTypes.MobileView);
        }
    }
}