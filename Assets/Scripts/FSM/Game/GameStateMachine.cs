using DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FMS.Game
{
    public class GameStateMachine : IGameStateMachine
    {
        private GameState _currentState;

        private Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();

        private PlayerInput _playerInput;

        [Inject]
        public void Construct(PlayerInput playerInput, IDialogueManager dialogueManager)
        {
            _playerInput = playerInput;

            PauseState pauseState = new PauseState(this, _playerInput);
            GameplayState gameplayState = new GameplayState(this, _playerInput);
            DialogueState dialogueState = new DialogueState(this, _playerInput);

            dialogueManager.DialogueStart += gameplayState.SetToDialogueState;
            dialogueManager.DialogueEnd += dialogueState.SetToGameplayState;

            AddState(pauseState);
            AddState(gameplayState);
            AddState(dialogueState);

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
