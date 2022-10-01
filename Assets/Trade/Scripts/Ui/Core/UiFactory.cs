using System;
using System.Collections.Generic;
using Trade.Scripts.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Trade.Scripts.Ui.Core
{
    public class UiFactory
    {
        private readonly Dictionary<Type, UiView> _prefabs = new Dictionary<Type, UiView>();
        private readonly GameObject _rootPrefab;
        private Transform _root;

        public UiFactory(UiConfiguration uiConfiguration)
        {
            _rootPrefab = uiConfiguration.Root;
            foreach (var prefab in uiConfiguration.Views)
            {
                _prefabs.Add(prefab.GetType(), prefab);
            }
        }
        
        public void Init()
        {
            _root = Object.Instantiate(_rootPrefab).transform;
        }

        public T Create<T>() where T : UiView
        {
            if (_prefabs.TryGetValue(typeof(T), out var prefab))
            {
                return (T) Object.Instantiate(prefab, _root);
            }
            throw new Exception($"View of type {typeof(T)} not found");
        }
    }
}