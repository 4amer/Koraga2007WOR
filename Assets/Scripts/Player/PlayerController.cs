using JoystickSystem;
using Player.Ability;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private Rigidbody _playerRb;
        
        [SerializeField]
        private float _movementSpeed;

        private Vector3 _playerMoveValue = Vector2.zero;

        private List<IAbility> _abilities = new List<IAbility>();

        private IAbility _selectedAbility = null;

        private int level = 0;

        public event Action<int> PlayerLevelChanged;
        public event Action<Vector2> playerRightStickInputed;
        public event Action<Vector2> playerLeftStickInputed;

        [Inject]
        public void Construct(IAbility[] abilities, LeftJoystick leftJoystick, RightJoystick rightJoystick)
        {
            leftJoystick.OnPointDrag += Move;

            rightJoystick.OnPointDrag += RightStickAction;
            rightJoystick.OnPointUp += ClearRightStickAction;

            foreach (IAbility ability in abilities)
            {
                ability.Initialization(PlayerLevelChanged, this);
                PlayerLevelChanged += ability.PlayerLevelIncresed;
                playerRightStickInputed += ability.StickInput;
                ability.Unlocked += AbilityUnlocked;
                _abilities.Add(ability);
            }
        }

        private void Awake()
        {
            
        }

        private void Update()
        {
            //Increse Level
            if (Input.GetKeyDown(KeyCode.V))
            {
                PlayerLevelUp();
            }
        }

        private void FixedUpdate()
        {
            Vector3 playerPosition = _player.transform.position;
            _playerRb.MovePosition(playerPosition + new Vector3(_playerMoveValue.x, 0, _playerMoveValue.y) * _movementSpeed);
        }

        public void Move(InputAction.CallbackContext context)
        {
            _playerMoveValue = context.action.ReadValue<Vector2>();
        }

        public void Move(Vector2 direction)
        {
            _playerMoveValue = direction;
            playerLeftStickInputed?.Invoke(direction);
        }

        // ability
        private void RightStickAction(Vector2 direction)
        {
            Vector3 playerPosition = _player.transform.position;
            Vector3 rayDirection = new Vector3(direction.x, playerPosition.y, direction.y);
            Ray ray = new Ray();
            ray.origin = playerPosition;
            ray.direction = rayDirection;
            _selectedAbility?.Update(ray);
            playerRightStickInputed?.Invoke(direction);
        }

        private void ClearRightStickAction()
        {
            _selectedAbility?.TryDoAction();
            playerRightStickInputed?.Invoke(Vector2.zero);
        }

        public void DoAbility(InputAction.CallbackContext context)
        {
            
        }

        private void AbilityUnlocked(IAbility ability)
        {
            _selectedAbility = ability;
        }

        public float MoveSpeed
        {
            set
            {
                _movementSpeed = value;
            }
        }

        private void PlayerLevelUp()
        {
            level += 1;
            PlayerLevelChanged?.Invoke(level);
        }
    }
}
