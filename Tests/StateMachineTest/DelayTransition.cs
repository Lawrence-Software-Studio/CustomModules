using StateMachineSystem;

public class DelayTransition : TransitionComponent {
    double _delay;
    double _elapsed = 0;

    public DelayTransition(
        string nextState,
        double delay)
    : base(nextState) {
        _delay = delay;
    }

    public override void fixedUpdate() {
    }

    public override bool goToNextState() {
        if (_elapsed >= _delay) {
            _elapsed = 0;
            return true;
        }

        return false;
    }

    public override void update(double deltaTime) {
        _elapsed += deltaTime;
        Console.WriteLine($"Elapsed {_elapsed}");
    }
}