using CutsceneSystem;
using DialogueSystem;
using JoystickSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FSM.Game
{
    public class GameStateMachine : IGameStateMachine, IGameStateMachineState, IGameStateMachineActions
    {
        private GameState _previousState = null;
        private GameState _currentState = null;

        private Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();

        private PlayerInput _playerInput;
        private IViewManager _viewManager;

        public event Action StateChanged;

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
                StateChanged?.Invoke();
                Debug.Log((StateChanged == null) + " state");

                _currentState?.Exit();

                _previousState = _currentState;

                _currentState = newState;

                _currentState?.Enter();
            }
        }

        public void SetToPreviousState()
        {
            if (_previousState == null || _currentState == null) return;
            
            StateChanged?.Invoke();

            _currentState?.Exit();
            
            var state = _previousState;
            
            _previousState = _currentState;
            
            _currentState = state;
            
            _currentState?.Enter();
        }

        public GameState PreviouseState
        {
            get
            {
                return _previousState;
            }
        }

        public GameState CurrentState
        {
            get
            {
                return _currentState;
            }
        }
    }

    public interface IGameStateMachine
    {
        void SetState<T>() where T : GameState;
        public void SetToPreviousState();
    }

    public interface IGameStateMachineState
    {
        public GameState PreviouseState { get; }
        public GameState CurrentState { get; }
    }

    public interface IGameStateMachineActions 
    { 
        public event Action StateChanged;
    }
}
