using CutsceneSystem;
using DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FSM.Game
{
    public class GameStateMachine : IGameStateMachine
    {
        private GameState _currentState;

        private Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();

        private PlayerInput _playerInput;
        private IViewManager _viewManager;

        [Inject]
        public void Construct(PlayerInput playerInput, IDialogueManager dialogueManager, ICutsceneManager cutsceneManager, IViewManager viewManager)
        {
            _playerInput = playerInput;
            _viewManager = viewManager;

            PauseState pauseState = new PauseState(this, _playerInput, _viewManager);
            GameplayState gameplayState = new GameplayState(this, _playerInput, _viewManager);
            DialogueState dialogueState = new DialogueState(this, _playerInput, _viewManager);
            CutsceneState cutsceneState = new CutsceneState(this, _playerInput, _viewManager);

            dialogueManager.DialogueStart += gameplayState.SetToDialogueState;
            dialogueManager.DialogueEnd += dialogueState.SetToGameplayState;

            cutsceneManager.CutsceneStarted += gameplayState.SetToCutsceneState;
            cutsceneManager.CutsceneEnded += cutsceneState.SetToGameplayState;

            AddState(pauseState);
            AddState(gameplayState);
            AddState(dialogueState);
            AddState(cutsceneState);

            SetState<GameplayState>();
        }

        private void AddState(GameState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : GameState
        {
            var type = typeof(T);

            if (_currentState?.GetType() == type)
            {
                return;
            }
            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();

                _currentState = newState;

                _currentState?.Enter();
            }
        }
    }

    public interface IGameStateMachine
    {
        void SetState<T>() where T : GameState;
    }
}
