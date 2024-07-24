using UI;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class DialogueState : GameState
    {
        private PlayerInput _playerInput = null;
        private IViewManager _viewManager = null;

        public DialogueState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm) 
        {
            _playerInput = playerInput;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            var inputActionMap = _playerInput.actions.FindActionMap("Dialogue");
            if (inputActionMap.enabled == false)
            {
                inputActionMap.Enable();
            }
            _playerInput.SwitchCurrentActionMap("Dialogue");
            _viewManager.ShowView(WindowTypes.DialogueView);
        }

        public void SetState()
        {
            if(Gsm.PreviouseState is CutsceneState)
            {
                Gsm.SetState<CutsceneState>();
            } 
            else
            {
                Gsm.SetState<GameplayState>();
            }
        }

        public override void Exit()
        {
            var inputActionMap = _playerInput.actions.FindActionMap("Dialogue");
            if (inputActionMap.enabled == true)
            {
                inputActionMap.Disable();
            }
            _viewManager.HideView(WindowTypes.DialogueView);
        }
    }
}