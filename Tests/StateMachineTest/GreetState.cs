using StateMachineSystem;

public class GreetState : StateComponent {
    int counter = 1;

    public override void fixedUpdate() {
    }

    public override void onEnter() {
        Console.WriteLine("Entering greet state");
        counter = 1;
    }

    public override void onExit() {
        Console.WriteLine("Exiting greet state");
    }

    public override void update(double deltaTime) {
        Console.WriteLine($"Greet counter {counter++}");
    }
}