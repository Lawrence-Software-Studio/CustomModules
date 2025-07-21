namespace StateMachineSystem {
    public abstract class StateComponent {
        public abstract void update(double deltaTime);
        public abstract void fixedUpdate();
        public abstract void onEnter();
        public abstract void onExit();
    }

    public class PlaceholderState : StateComponent {
        public readonly static PlaceholderState Instance = new PlaceholderState();

        public override void fixedUpdate() {
        }

        public override void onEnter() {
        }

        public override void onExit() {
        }

        public override void update(double deltaTime) {
        }
    }
}