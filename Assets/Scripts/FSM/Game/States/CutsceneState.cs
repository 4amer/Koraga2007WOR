using CutsceneSystem;

namespace FSM.Game
{
    public class CutsceneState : GameState
    {
        private ICutsceneManager _cutsceneManager;

        public CutsceneState(GameStateMachine gsm, ICutsceneManager cutsceneManager) : base(gsm)
        {
            _cutsceneManager = cutsceneManager;
        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public void SetToDialogueState()
        {
            Gsm.SetState<DialogueState>();
        }

        public override void Enter()
        {
            if (Gsm.PreviouseState is DialogueState) _cutsceneManager.ResumeCutscene();
        }

        public override void Exit()
        {
            _cutsceneManager.PauseCutscene();
        }
    }
}
