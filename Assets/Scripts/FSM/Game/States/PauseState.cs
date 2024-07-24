using UI;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class PauseState : GameState
    {
        private PlayerInput _playerInput = null;
        private IViewManager _viewManager = null;

        public PauseState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm)
        {
            _playerInput = playerInput;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            _playerInput.SwitchCurrentActionMap("UI");
            _viewManager.ShowView(WindowTypes.MenuView);
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public override void Exit()
        {
            _viewManager.HideView(WindowTypes.MenuView);
        }
    }
}