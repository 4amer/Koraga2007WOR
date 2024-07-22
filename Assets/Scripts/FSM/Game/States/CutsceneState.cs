using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace FSM.Game
{
    public class CutsceneState : GameState
    {
        public CutsceneState(GameStateMachine gsm, PlayerInput playerInput, IViewManager viewManager) : base(gsm, playerInput, viewManager)
        {

        }

        public void SetToGameplayState()
        {
            Gsm.SetState<GameplayState>();
        }

        public void SetToDialogueState()
        {
            Gsm.SetState<DialogueState>();
        }
    }
}
