namespace EntityComponentSystem {
    public class Entity {
        public readonly int EntityId;
        private Dictionary<Type, Component> _components = [];

        public Entity(int entityId) {
            EntityId = entityId;
        }

        public void addComponent(Component component) {
            Type type = component.GetType();
            Console.WriteLine(type);
            _components.Add(type, component);
        }

        public void removeComponent(Type type) {
            _components.Remove(type);
        }

        public bool hasComponent(Type type) {
            return _components.ContainsKey(type);
        }

        public T? GetComponent<T>() where T : Component {
            Type type = typeof(T);
            return _components[type] as T;
        }
    }

    public abstract class Component {
    }
}
