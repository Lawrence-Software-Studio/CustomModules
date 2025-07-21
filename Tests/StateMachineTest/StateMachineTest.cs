using StateMachineSystem;
using Timer = System.Timers.Timer;

public class StateMachineTest {
    public static void main() {
        StateMachine stateMachine = new StateMachine();
        StateComponent component1 = new GreetState();
        TransitionComponent delayTransition1 = new DelayTransition("quiet", 5000);
        StateComponent component2 = new QuietState();
        TransitionComponent delayTransition2 = new DelayTransition("greet", 5000);

        stateMachine.addState("greet", component1, delayTransition1);
        stateMachine.addState("quiet", component2, delayTransition2);
        stateMachine.start("greet");

        Timer timer = new Timer(1000);
        timer.Elapsed += (sender, e) => stateMachine.update(1000);
        timer.AutoReset = true;
        timer.Enabled = true;

        while (true) {}
    }
}