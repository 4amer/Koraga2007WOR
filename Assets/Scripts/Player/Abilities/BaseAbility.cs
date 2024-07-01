using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Player.Ability 
{
    public abstract class BaseAbility
    {
        protected abstract string _name { get; set; }
        protected abstract Sprite _sprite { get; set; }
        protected abstract int _levelToUnlock { get; set; }
        protected abstract float _cooldown { get; set; }

        private Action _playerInput;

        public event Action Unlocked;

        public void Initialization(Action<int> playerLevelChanget, Action playerInput, PlayerAction action)
        {
            playerLevelChanget += PlayerLevelIncresed;
            _playerInput = playerInput;
        }

        private void UpdateValue()
        {

        }

        private void Unlock()
        {
            Unlocked?.Invoke();
        }

        public void Pick()
        {
            _playerInput += DoAction;
        }

        public void Unpick()
        {
            _playerInput -= DoAction;
        }

        private void DoAction()
        {
            
        }

        private void PlayerLevelIncresed(int level)
        {
            if (level >= _levelToUnlock)
            {
                Unlock();
            }
        }
    }

    public interface IAbility
    {
        void Initialization(Action<int> playerLevelChanget);
    }
}
