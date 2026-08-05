using System.Collections.Generic;

namespace Script.Logic
{
    public partial class PlayerController
    {
        private Dictionary<string, IPlayerComponent> bag = new();

        public void AddComponent(string key, IPlayerComponent component)
        {
            bag[key] = component;
        }

        public bool TryGetAllComponent<T>(string key, out T component)
        {
            if (bag.TryGetValue(key, out IPlayerComponent c) && c is T typedComponent)
            {
                component = typedComponent;
                return true;
            }
            
            component = default;
            return false;
            
        }

        public bool TryGetFirstComponent<T>(out T component)
        {
            foreach ((string key, IPlayerComponent value) in bag)
            {
                if (value is T typedComponent)
                {
                    component = typedComponent;
                    return true;
                }
            }
            
            component = default;
            return false;
        }
    }
}