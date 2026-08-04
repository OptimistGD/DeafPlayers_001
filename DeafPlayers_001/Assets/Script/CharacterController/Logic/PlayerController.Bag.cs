using System.Collections.Generic;

namespace Script.Logic
{
    public partial class PlayerController
    {
        public interface IComponentProperty
        {
        }
        private class PlayerComponentProperty<T> : IComponentProperty
        {
            public readonly T component;

            public PlayerComponentProperty(T component)
            {
                this.component = component;
            }
        }

        private Dictionary<string, IComponentProperty> bag = new();

        public void AddComponent<T>(string key, T component)
        {
            bag[key] = new PlayerComponentProperty<T>(component);
        }

        public bool TryGetComponent<T>(string key, out T component)
        {
            if (bag.TryGetValue(key, out IComponentProperty property) &&
                property is PlayerComponentProperty<T> componentProperty)
            {
                component = componentProperty.component;
                return true;
            }
            
            component = default;
            return false;
        }

        public bool TryGetFirstComponent<T>(out T component)
        {
            foreach ((string key, IComponentProperty value) in bag)
            {
                if (value is PlayerComponentProperty<T> componentProperty)
                {
                    component = componentProperty.component;
                    return true;
                }
            }
            
            component = default;
            return false;
        }
    }
}