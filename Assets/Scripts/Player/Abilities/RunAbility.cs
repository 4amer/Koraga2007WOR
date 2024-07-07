using Player.Ability;
using UnityEngine;

namespace Player.Ability
{
    public class RunAbility : BaseAbility
    {
        protected override string _name { get; set; } = "Run";
        protected override Sprite _sprite { get; set; } = Resources.Load<Sprite>("Sprites/Characters/koraga");
        protected override int _levelToUnlock { get; set; } = 1;
        protected override float _cooldown { get; set; } = 0f;
        protected override IInputable _inputable { get; set; } = new NonInputable();

        private float _runPlayerSpeed = 0.1f;

        protected override void Unlock()
        {
            base.Unlock();
            _player.MoveSpeed = _runPlayerSpeed;
        }
    }
}
