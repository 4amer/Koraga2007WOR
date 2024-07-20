using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace MobileInput
{
    public class ScreenButton : MonoBehaviour, IScreenButton
    {
        [SerializeField] private ButtonBehaviour buttons = ButtonBehaviour.None;
        [SerializeField] private Button button = null;

        public Button Button { 
            get 
            { 
                return button; 
            } 
        } 
        public ButtonBehaviour ButtonBehaviour 
        { 
            get 
            { 
                return buttons; 
            } 
        }
    }

    public interface IScreenButton
    {
        public ButtonBehaviour ButtonBehaviour { get; }
    }

    public enum ButtonBehaviour
    {
        None = 0,
        Action = 1,
    }
}