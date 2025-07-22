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
        [JsonInclude]
        [JsonPropertyName("side_effect")]
        public readonly Dictionary<string, object>? SideEffect;

        [JsonConstructor]
        public DialogueNode(int id, int text_id, Dictionary<string, object>? side_effect = null) {
            Id = id;
            TextId = text_id;
            SideEffect = side_effect;
        }
    }

    public class TextNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        public readonly int NextNode; // Use -1 to terminate the dialogue chain

        public TextNode(int id, int text_id, int next_node, Dictionary<string, object>? side_effect = null) : base(id, text_id, side_effect) {
            NextNode = next_node;
        }
    }

    public class QuestionNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("answers")]
        public int[] Answers = [];

        public QuestionNode(int id, int text_id, int[] answers, Dictionary<string, object>? side_effect = null) : base(id, text_id, side_effect) {
            Answers = answers;
        }
    }
}
