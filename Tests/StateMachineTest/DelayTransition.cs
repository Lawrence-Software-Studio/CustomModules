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
            return true;
        }

        return false;
    }

    public override void onEnter() {
        _elapsed = 0;
    }

    public override void onExit() {
    }

    public override void update(double deltaTime) {
        _elapsed += deltaTime;
        Console.WriteLine($"Elapsed {_elapsed}");
    }
}