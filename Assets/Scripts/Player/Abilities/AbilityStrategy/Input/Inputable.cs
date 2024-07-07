using Player;
using UnityEngine;

namespace Player.Ability
{
    public class Inputable : IInputable
    {
        public void DoAction(PlayerController player)
        {
            Debug.Log("Player Input");
        }
    }
}