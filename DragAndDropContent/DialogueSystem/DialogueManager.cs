using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueManager {
        [JsonInclude]
        [JsonPropertyName("nodes")]
        private DialogueNode[] _nodes = [];

        public DialogueManager() {
        }

        public DialogueManager(int size) {
            _nodes = new DialogueNode[size];
        }

        public void setNode(int id, DialogueNode node) {
            _nodes[id] = node;
        }

        public DialogueNode getNode(int id) {
            return _nodes[id];
        }
    }
}