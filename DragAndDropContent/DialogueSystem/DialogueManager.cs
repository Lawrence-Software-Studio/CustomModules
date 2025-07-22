using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueManager {
        [JsonInclude]
        [JsonPropertyName("nodes")]
        private Dictionary<string, DialogueNode> _nodes = [];

        public void addNode(DialogueNode node) {
            _nodes.Add(node.getId(), node);
        }

        public DialogueNode getNode(string nodeKey) {
            return _nodes[nodeKey];
        }
    }
}