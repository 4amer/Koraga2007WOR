using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

namespace UI
{
    public class BaseView : MonoBehaviour
    {
        [SerializeField] private WindowTypes _type = WindowTypes.None;
        public void Show()
        {
            gameObject.active = true;
        }

        public void Hide()
        {
            gameObject.active = false;
        }

        public WindowTypes Type
        {
            get
            {
                return _type;
            }
        }
    }
}