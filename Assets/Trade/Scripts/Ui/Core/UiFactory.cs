using System;
using System.Collections.Generic;
using Trade.Scripts.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Trade.Scripts.Ui.Core
{
    public class UiFactory
    {
        private readonly Dictionary<Type, UiWindow> _prefabs = new Dictionary<Type, UiWindow>();
        private readonly GameObject _rootPrefab;
        private Transform _root;

        public UiFactory(UiConfiguration uiConfiguration)
        {
            _rootPrefab = uiConfiguration.Root;
            foreach (var prefab in uiConfiguration.Windows)
            {
                _prefabs.Add(prefab.GetType(), prefab);
            }
        }
        
        public void Init()
        {
            _root = Object.Instantiate(_rootPrefab).transform;
        }

        public T Create<T>() where T : UiWindow
        {
            if (_prefabs.TryGetValue(typeof(T), out var prefab))
            {
                return (T) Object.Instantiate(prefab, _root);
            }
            throw new Exception($"Window of type {typeof(T)} not found");
        }
    }
}