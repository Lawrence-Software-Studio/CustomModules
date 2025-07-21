using System.Text.Json.Serialization;

namespace DialogueSystem {
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "node_type")]
    [JsonDerivedType(typeof(TextNode), typeDiscriminator: "text")]
    [JsonDerivedType(typeof(QuestionNode), typeDiscriminator: "question")]
    public abstract class DialogueNode {
        [JsonInclude]
        [JsonPropertyName("id")]
        public readonly int Id;
        [JsonInclude]
        [JsonPropertyName("text_id")]
        public readonly int TextId;

        [JsonConstructor]
        public DialogueNode(int id, int text_id) {
            Id = id;
            TextId = text_id;
        }
    }

    public class TextNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        public readonly int NextNode; // Use -1 to terminate the dialogue chain

        public TextNode(int id, int text_id, int next_node) : base(id, text_id) {
            NextNode = next_node;
        }
    }

    public class QuestionNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("answers")]
        public int[] Answers = [];

        public QuestionNode(int id, int text_id, int[] answers) : base(id, text_id) {
            Answers = answers;
        }
    }
}
