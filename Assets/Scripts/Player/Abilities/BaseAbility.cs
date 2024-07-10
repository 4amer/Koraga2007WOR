using System;
using System.Threading.Tasks;
using UnityEngine;
using Utils.Extentions;

namespace Player.Ability 
{
    public abstract class BaseAbility : IAbility
    {
        private const float StickDeathZoneToAction = 0.33f;
        protected abstract string _name { get; set; }
        protected abstract Sprite _sprite { get; set; }
        protected abstract int _levelToUnlock { get; set; }
        protected abstract float _cooldown { get; set; }

        public event Action<IAbility> Unlocked;

        private bool _isCooldown = false;

        protected PlayerController _player = null;
        /* Do nothing */ protected abstract IInputable _inputable { get; set; }

        protected Vector2 stickDirection = Vector2.zero;

        public void Initialization(Action<int> playerLevelChanget, PlayerController player)
        {
            playerLevelChanget += PlayerLevelIncresed;
            _player = player;
        }

        public virtual void Update(Ray ray)
        {

        }

        protected virtual void Unlock()
        {
            Unlocked?.Invoke(this);
        }

        protected virtual void DoAction()
        {

        }

        public virtual void TryDoAction()
        {
            float maxDirection = stickDirection.HighestAbsValue();
            if (maxDirection > StickDeathZoneToAction)
            {
                if (_isCooldown == true) return;
                _isCooldown = true;
                WaitCooldown();

                DoAction();
            }
        }

        public void StickInput(Vector2 direction)
        {
            stickDirection = direction;
        }

        public void PlayerLevelIncresed(int level)
        {
            if (level >= _levelToUnlock)
            {
                Unlock();
            }
        }

        private async void WaitCooldown()
        {
            await Task.Delay(Mathf.RoundToInt(_cooldown * 1000f));
            _isCooldown = false;
        }
    }

    public interface IAbility
    {
        public void Initialization(Action<int> playerLevelChanget, PlayerController player);
        public void TryDoAction();
        public void StickInput(Vector2 direction);
        public void Update(Ray ray);
        public event Action<IAbility> Unlocked;
        public void PlayerLevelIncresed(int level);
    }
}