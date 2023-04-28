
using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace Controllers
{
    public class EventDispatcherController
    {
        private Dictionary<Type, List<Delegate>> _listeners;

        public void AddListener<T>(Action<T> listener)
        {
            if (_listeners.ContainsKey(typeof(T)))
            {
                _listeners[typeof(T)].Add(listener);
            }
        }
        
        public void RemoveListener<T>(Action<T> listener)
        {
            
        }

        public void Raise(Type eventType)
        {
            //_listeners[eventType].ForEach(listener => listener.);
        }
    }
}