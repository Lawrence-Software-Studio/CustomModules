using System.Text.Json.Serialization;

namespace DialogueSystem {
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "node_type")]
    [JsonDerivedType(typeof(TextNode), typeDiscriminator: "text")]
    [JsonDerivedType(typeof(QuestionNode), typeDiscriminator: "question")]
    public abstract class DialogueNode {
        [JsonInclude]
        [JsonPropertyName("id")]
        public string Id;
        [JsonInclude]
        [JsonPropertyName("text_id")]
        public string TextId;
        [JsonInclude]
        [JsonPropertyName("side_effect")]
        public Dictionary<string, string>? SideEffect;

        public DialogueNode() {

        }

        public DialogueNode(string id, string text_id, Dictionary<string, string>? side_effect = null) {
            Id = id;
            TextId = text_id;
            SideEffect = side_effect;
        }
    }

    public class TextNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        public string NextNode; // Use -1 to terminate the dialogue chain

        public TextNode() {
        }

        public TextNode(string id, string text_id, string next_node, Dictionary<string, string>? side_effect = null) : base(id, text_id, side_effect) {
            NextNode = next_node;
        }
    }

    public class QuestionNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("answers")]
        public string[] Answers = [];

        public QuestionNode() {

        }

        public QuestionNode(string id, string text_id, string[] answers, Dictionary<string, string>? side_effect = null) : base(id, text_id, side_effect) {
            Answers = answers;
        }
    }
}
