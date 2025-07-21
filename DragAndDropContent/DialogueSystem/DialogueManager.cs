using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueManager {
        [JsonInclude]
        [JsonPropertyName("nodes")]
        private Dictionary<int, DialogueNode> _nodes = [];

        public void addNode(DialogueNode node) {
            _nodes.Add(node.Id, node);
        }

        public DialogueNode getNode(int nodeKey) {
            return _nodes[nodeKey];
        }
    }
}