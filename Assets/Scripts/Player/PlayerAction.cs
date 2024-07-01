using Player.Ability;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class PlayerAction : MonoBehaviour
    {
        private List<IAbility> _abilities = new List<IAbility>();

        private IAbility _selectedAbility = null;

        [Inject]
        public void Construct(IAbility[] abilities)
        {
            
        }

        public void DoAbility(InputAction.CallbackContext context)
        {
            Vector2 position = context.action.ReadValue<Vector2>();
        }
    }
}