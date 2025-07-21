namespace StateMachineSystem {
    public abstract class TransitionComponent {
        public readonly string NextState;

        public TransitionComponent(string nextState) {
            NextState = nextState;
        }

        public abstract bool goToNextState();
        public abstract void update(double deltaTime);
        public abstract void fixedUpdate();
        public abstract void onEnter();
        public abstract void onExit();
    }

    public class PlaceholderTransition : TransitionComponent {
        public readonly static PlaceholderTransition Instance = new PlaceholderTransition("");

        public PlaceholderTransition(string nextState) : base(nextState) {
        }

        public override void fixedUpdate() {
        }

        public override bool goToNextState() {
            return false;
        }

        public override void onEnter() {
        }

        public override void onExit() {
        }

        public override void update(double deltaTime) {
        }
    }
}