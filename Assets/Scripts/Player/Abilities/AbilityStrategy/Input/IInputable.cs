using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ability
{
    public interface IInputable
    {
        void DoAction(PlayerController player);
    }
}
