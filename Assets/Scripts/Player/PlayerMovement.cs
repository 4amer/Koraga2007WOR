using System;
using Player.Ability;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private Rigidbody _playerRb;
        
        [SerializeField]
        private float _movementSpeed;

        private Vector3 _playerMoveValue = new Vector2(0,0);

        private void FixedUpdate()
        {
            Vector3 playerPosition = _player.transform.position;
            _playerRb.MovePosition(playerPosition + new Vector3(_playerMoveValue.x, 0, _playerMoveValue.y) * _movementSpeed);
        }

        public void Move(InputAction.CallbackContext context)
        {
            _playerMoveValue = context.action.ReadValue<Vector2>();
        }
    }
}
