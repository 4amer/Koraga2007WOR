using UnityEngine;
using UnityEngine.Events;

namespace Interactions.Doors
{
    public class DoorWithLock : MonoBehaviour
    {
        [SerializeField] private Key[] _keys = null;
        [SerializeField] private GameObject[] _doors = null;
        [SerializeField] private UnityEvent[] _whenDoorOpenEvents = null;

        private int collectedKeysCounter = 0;

        private void Awake()
        {
            foreach (Key key in _keys)
            {
                key.PlayerPickUpKey += KeyPicked;
            }
        }

        private void KeyPicked()
        {
            collectedKeysCounter++;
            if (collectedKeysCounter >= _keys.Length)
            {
                foreach (UnityEvent Event in _whenDoorOpenEvents)
                {
                    Event?.Invoke();
                }

                foreach (GameObject door in _doors)
                {
                    OpenDoor(door);
                }
            }
        }

        private void OpenDoor(GameObject door)
        {
            door.active = false;
        }
    }
}