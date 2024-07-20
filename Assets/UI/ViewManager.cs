using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using Zenject;

namespace UI
{
    public sealed class ViewManager : MonoBehaviour, IViewManager
    {
        [SerializeField] private WindowTypes _startView = WindowTypes.None;
        [SerializeField] private BaseView[] _views = null;

        private List<BaseView> viewStack = new List<BaseView>();

        public event Action<WindowTypes> viewShowed;
        public event Action<WindowTypes> viewHided;

        private BaseView _currentView = null;
        private BaseView _previouseView = null;

        private void Start()
        {
            ShowView(_startView);
        }

        public void ShowView(WindowTypes type)
        {
            BaseView view = FindView(type);
            view.Show();
            viewStack.Add(view);
            viewShowed?.Invoke(type);
        }

        public void HideView(WindowTypes type)
        {
            BaseView view = FindView(type);
            view.Hide();
            viewStack.Remove(view);
            viewHided?.Invoke(type);
        }

        public void ChangeView(WindowTypes type)
        {
            BaseView view = FindView(type);
            _previouseView = _currentView;
            _currentView = view;
            _currentView.Show();
            _previouseView.Hide();
            viewStack.Remove(_previouseView);
        }

        private BaseView FindView(WindowTypes type)
        {
            BaseView baseView = null;
            foreach (BaseView view in _views)
            {
                if (view.Type == type)
                {
                    baseView = view;
                    break;
                }
            }
            return baseView;
        }
    }
    public interface IViewManager
    {
        public event Action<WindowTypes> viewShowed;
        public event Action<WindowTypes> viewHided;
        void ChangeView(WindowTypes type);
        void ShowView(WindowTypes type);
        void HideView(WindowTypes type);
    }
}