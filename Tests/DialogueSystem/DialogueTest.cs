using System.Text.Json;
using DialogueSystem;

public class DialogueTest {
    public static void main() {
        DialogueText one = new DialogueText(0, "Hello");
        DialogueText two = new DialogueText(1, "How are you?");
        DialogueText three = new DialogueText(2, "I'm fine.");
        DialogueText four = new DialogueText(3, "I could be better.");
        DialogueText five = new DialogueText(4, "I'm ill.");
        DialogueText six = new DialogueText(5, "I see.");

        DialogueNode nodeOne = new TextNode(0, 1, 0);
        DialogueNode nodeTwo = new QuestionNode(1, [
           2, 3, 4
        ]);

        DialogueNode nodeThree = new TextNode(2, 5, 1);
        DialogueNode nodeFour = new TextNode(3, 5, 1);
        DialogueNode nodeFive = new TextNode(4, 5, 1);
        DialogueNode nodeSix = new TextNode(5, -1, 1);

        Console.WriteLine(JsonSerializer.Serialize(nodeOne));
        Console.WriteLine(JsonSerializer.Serialize(nodeTwo));
        Console.WriteLine(JsonSerializer.Serialize(nodeSix));

        DialogueManager dialogueManager = new DialogueManager(6);
        dialogueManager.setNode(0, nodeOne);
        dialogueManager.setNode(1, nodeTwo);
        dialogueManager.setNode(2, nodeThree);
        dialogueManager.setNode(3, nodeFour);
        dialogueManager.setNode(4, nodeFive);
        dialogueManager.setNode(5, nodeSix);

        TextRepository repository = new TextRepository(6);
        repository.setText(0, one);
        repository.setText(1, two);
        repository.setText(2, three);
        repository.setText(3, four);
        repository.setText(4, five);
        repository.setText(5, six);

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
        int current = 0;
        while (current != -1) {
            DialogueNode node = dialogueManager.getNode(current);

            if (node is TextNode t) {
                Console.WriteLine(repository.getText(t.getTextId()));
                current = t.getNextNode();
            } else if (node is QuestionNode q) {
                Console.WriteLine(repository.getText(q.getTextId()));

                int choice = -1;

                foreach (int i in q.getAnswers()) {
                    TextNode answer = (TextNode)dialogueManager.getNode(i);
                    Console.WriteLine(repository.getText(answer.getTextId()));

                    if (choice != -1) {
                        continue;
                    }

                    choice = answer.getNextNode();
                }
                current = choice;
            }
        }
    }
}