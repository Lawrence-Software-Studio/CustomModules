using System.Text.Json.Serialization;

namespace DialogueSystem {
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "node_type")]
    [JsonDerivedType(typeof(TextNode), typeDiscriminator: "text")]
    [JsonDerivedType(typeof(QuestionNode), typeDiscriminator: "question")]
    public abstract class DialogueNode {
        [JsonInclude]
        [JsonPropertyName("id")]
        private string _id = "";
        [JsonInclude]
        [JsonPropertyName("text_id")]
        private string _textId = "";
        [JsonInclude]
        [JsonPropertyName("side_effect")]
        private Dictionary<string, string>? _sideEffect;

        public DialogueNode() {
        }

        public DialogueNode(string id, string text_id, Dictionary<string, string>? side_effect = null) {
            _id = id;
            _textId = text_id;
            _sideEffect = side_effect;
        }

        public string getId() {
            return _id;
        }

        public string getTextId() {
            return _textId;
        }

        public Dictionary<string, string>? getSideEffect() {
            return _sideEffect;
        }
    }

    public class TextNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        private string _nextNode = ""; // Use -1 to terminate the dialogue chain

        public TextNode() {
        }

        public TextNode(string id, string text_id, string next_node, Dictionary<string, string>? side_effect = null) : base(id, text_id, side_effect) {
            _nextNode = next_node;
        }

        public string getNextNode() {
            return _nextNode;
        }
    }

    public class QuestionNode : DialogueNode {
        [JsonInclude]
        [JsonPropertyName("answers")]
        private string[] _answers = [];

        public QuestionNode() {
        }

        public QuestionNode(string id, string text_id, string[] answers, Dictionary<string, string>? side_effect = null) : base(id, text_id, side_effect) {
            _answers = answers;
        }

        public string[] getAnswers() {
            return _answers;
        }
    }
}
