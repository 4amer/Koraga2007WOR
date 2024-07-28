using System;
using UnityEngine;

namespace Interactions.Doors
{
    public class Key : MonoBehaviour
    {
        public event Action PlayerPickUpKey;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerPickUpKey?.Invoke();
                gameObject.active = false;
            }
        }
}
}