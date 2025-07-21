namespace StateMachineSystem {
    public class StateMachine {
        private Dictionary<string, StateComponent> _states = [];
        private Dictionary<string, TransitionComponent> _transitions = [];
        private StateComponent _currentState = PlaceholderState.Instance;
        private TransitionComponent _currentTransition = PlaceholderTransition.Instance;

        public void addState(string key, StateComponent state, TransitionComponent transition) {
            _states.Add(key, state);
            _transitions.Add(key, transition);
        }

        public void update(double deltaTime) {
            _currentTransition.update(deltaTime);

            if (_currentTransition.goToNextState()) {
                switchState(_currentTransition.NextState);
            }

            _currentState.update(deltaTime);
        }

        public void fixedUpdate() {
            _currentTransition.fixedUpdate();

            if (_currentTransition.goToNextState()) {
                switchState(_currentTransition.NextState);
            }

            _currentState.fixedUpdate();
        }

        public void start(string startState) {
            switchState(startState);
        }

        public void switchState(string nextState) {
            _currentState.onExit();
            _currentTransition.onExit();

            _currentState = _states[nextState];
            _currentTransition = _transitions[nextState];

            _currentState.onEnter();
            _currentTransition.onEnter();
        }
    }
}
