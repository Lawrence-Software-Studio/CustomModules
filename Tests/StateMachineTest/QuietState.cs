using StateMachineSystem;

public class QuietState : StateComponent {
    int counter = 1;

    public override void fixedUpdate() {
    }

    public override void onEnter() {
        Console.WriteLine("Entering quiet state");
        counter = 1;
    }

    public override void onExit() {
        Console.WriteLine("Exiting quiet state");
    }

    public override void update(double deltaTime) {
        Console.WriteLine($"Quiet counter {counter++}");
    }
}