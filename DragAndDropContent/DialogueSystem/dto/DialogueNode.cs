using System.Text.Json.Serialization;

// JSON can have additional identifier info that won't be parsed and mapped for human readability.
namespace DialogueSystem {
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "node_type")]
    [JsonDerivedType(typeof(TextNode), typeDiscriminator: "text")]
    [JsonDerivedType(typeof(QuestionNode), typeDiscriminator: "question")]
    [JsonDerivedType(typeof(RpcNode), typeDiscriminator: "rpc")]
    [JsonDerivedType(typeof(ConditionNode), typeDiscriminator: "condition")]
    public abstract class DialogueNode {
    }

    public class TextNode : DialogueNode, HasText, HasNextNode {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        private int _nextNode; // Use -1 to terminate the dialogue chain
        [JsonInclude]
        [JsonPropertyName("character_id")]
        private int _characterId;
        [JsonInclude]
        [JsonPropertyName("text_id")]
        private int _textId;

        public TextNode() {
        }

        public TextNode(int text_id, int next_node, int character_id) {
            _nextNode = next_node;
            _characterId = character_id;
            _textId = text_id;
        }

        public int getNextNode() {
            return _nextNode;
        }

        public int getCharacterId() {
            return _characterId;
        }

        public int getTextId() {
            return _textId;
        }
    }

    public class QuestionNode : DialogueNode, HasText {
        [JsonInclude]
        [JsonPropertyName("answer_nodes")]
        private int[] _answerNodes = [];
        [JsonInclude]
        [JsonPropertyName("text_id")]
        private int _textId;

        public QuestionNode() {
        }

        public QuestionNode(int text_id, int[] answer_nodes) {
            _answerNodes = answer_nodes;
            _textId = text_id;
        }

        public int[] getAnswers() {
            return _answerNodes;
        }

        public int getTextId() {
            return _textId;
        }
    }

    public class RpcNode : DialogueNode, HasNextNode, HasParameters {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        private int _nextNode; // Use -1 to terminate the dialogue chain
        [JsonInclude]
        [JsonPropertyName("parameters")]
        private string[] _parameters = [];

        public RpcNode() {
        }

        public RpcNode(int next_node, string[] parameters) {
            _nextNode = next_node;
            _parameters = parameters;
        }

        public int getNextNode() {
            return _nextNode;
        }

        public string[] getParameters() {
            return _parameters;
        }
    }

    public class ConditionNode : DialogueNode, HasNextNode, HasParameters {
        [JsonInclude]
        [JsonPropertyName("next_node")]
        private int _nextNode; // Use -1 to terminate the dialogue chain
        [JsonInclude]
        [JsonPropertyName("parameters")]
        private string[] _parameters = [];

        public int getNextNode() {
            return _nextNode;
        }

        public string[] getParameters() {
            return _parameters;
        }
    }

    public interface HasNextNode {
        public int getNextNode();
    }

    public interface HasText {
        public int getTextId();
    }

    /*
        Index       value
        0           process ID to determine how to parse other values
        1           param 1
        2           param 2
        ...

        Example:
        0           greater_than
        1           key_1
        2           key_2
        3           true_node
        4           false_node
        if (npc_values[key_1] > npc_values[key_2]) {
            return true_node
        } else {
            return false_node
        }
    */
    public interface HasParameters {
        public string[] getParameters();
    }
}
