using System.Text.Json;
using DialogueSystem;

public class DialogueTest {
    public static void main() {
        DialogueText one = new DialogueText(1, "Hello");
        DialogueText two = new DialogueText(2, "How are you?");
        DialogueText three = new DialogueText(3, "I'm fine.");
        DialogueText four = new DialogueText(4, "I could be better.");
        DialogueText five = new DialogueText(5, "I'm ill.");
        DialogueText six = new DialogueText(6, "I see.");

        DialogueNode nodeOne = new TextNode(1, 1, 2);
        DialogueNode nodeTwo = new QuestionNode(2, 2, [
            3, 4, 5
    ]);
        DialogueNode nodeThree = new TextNode(3, 3, 6);
        DialogueNode nodeFour = new TextNode(4, 4, 6);
        DialogueNode nodeFive = new TextNode(5, 5, 6);
        DialogueNode nodeSix = new TextNode(6, 6, -1);

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
        dialogueManager.addText(one);
        dialogueManager.addText(two);
        dialogueManager.addText(three);
        dialogueManager.addText(four);
        dialogueManager.addText(five);
        dialogueManager.addText(six);


        int current = 1;
        while (current != -1) {
            DialogueNode node = dialogueManager.getNode(current);

            if (node is TextNode t) {
                Console.WriteLine(dialogueManager.getText(t.TextId));
                current = t.NextNode;
            } else if (node is QuestionNode q) {
                Console.WriteLine(dialogueManager.getText(q.TextId));

                int choice = -1;

                foreach (int i in q.Answers) {
                    TextNode answer = (TextNode)dialogueManager.getNode(i);
                    Console.WriteLine(dialogueManager.getText(answer.TextId));

                    if (choice != -1) {
                        continue;
                    }

                    choice = answer.NextNode;
                }
                current = choice;
            }
        }

        Console.WriteLine(JsonSerializer.Serialize(dialogueManager));
    }
}