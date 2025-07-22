using System.Text.Json;
using DialogueSystem;

public class DialogueTest {
    public static void main() {
        DialogueText one = new DialogueText("1", "Hello");
        DialogueText two = new DialogueText("2", "How are you?");
        DialogueText three = new DialogueText("3", "I'm fine.");
        DialogueText four = new DialogueText("4", "I could be better.");
        DialogueText five = new DialogueText("5", "I'm ill.");
        DialogueText six = new DialogueText("6", "I see.");

        DialogueNode nodeOne = new TextNode("1", "1", "2");
        DialogueNode nodeTwo = new QuestionNode("2", "2", [
            "3", "4", "5"
        ]);

        DialogueNode nodeThree = new TextNode("3", "3", "6");
        DialogueNode nodeFour = new TextNode("4", "4", "6");
        DialogueNode nodeFive = new TextNode("5", "5", "6");
        DialogueNode nodeSix = new TextNode("6", "6", "-1", new Dictionary<string, string> {
            {"process_id", "1"},
            {"message", "helloworld"}
        });

        Console.WriteLine(JsonSerializer.Serialize(nodeOne));
        Console.WriteLine(JsonSerializer.Serialize(nodeTwo));
        Console.WriteLine(JsonSerializer.Serialize(nodeSix));

        DialogueManager dialogueManager = new DialogueManager();
        dialogueManager.addNode(nodeOne);
        dialogueManager.addNode(nodeTwo);
        dialogueManager.addNode(nodeThree);
        dialogueManager.addNode(nodeFour);
        dialogueManager.addNode(nodeFive);
        dialogueManager.addNode(nodeSix);

        TextRepository repository = new TextRepository();
        repository.setText(one);
        repository.setText(two);
        repository.setText(three);
        repository.setText(four);
        repository.setText(five);
        repository.setText(six);

        iterateOverDialogues(dialogueManager, repository);

        string json = JsonSerializer.Serialize(dialogueManager);
        Console.WriteLine($"Dialogue manager json: \n {json}");
        string json2 = JsonSerializer.Serialize(repository);
        Console.WriteLine($"Repository json: \n {json2}");

        DialogueManager dm2 = JsonSerializer.Deserialize<DialogueManager>(json) ?? new DialogueManager();
        TextRepository r2 = JsonSerializer.Deserialize<TextRepository>(json2) ?? new TextRepository();

        iterateOverDialogues(dm2, r2);
    }

    public static void iterateOverDialogues(DialogueManager dialogueManager, TextRepository repository) {
        string current = "1";
        while (current != "-1") {
            DialogueNode node = dialogueManager.getNode(current);

            if (node is TextNode t) {
                Console.WriteLine(repository.getText(t.getTextId()));
                current = t.getNextNode();
            } else if (node is QuestionNode q) {
                Console.WriteLine(repository.getText(q.getTextId()));

                string choice = "-1";

                foreach (string i in q.getAnswers()) {
                    TextNode answer = (TextNode)dialogueManager.getNode(i);
                    Console.WriteLine(repository.getText(answer.getTextId()));

                    if (choice != "-1") {
                        continue;
                    }

                    choice = answer.getNextNode();
                }
                current = choice;
            }

            if (node.getSideEffect() != null) {
                if (node.getSideEffect()?["process_id"] == "1") {
                    Console.WriteLine(node.getSideEffect()?["message"]);
                }
            }
        }
    }
}