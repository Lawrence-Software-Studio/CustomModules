using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueManager {
        [JsonInclude]
        [JsonPropertyName("nodes")]
        public Dictionary<string, DialogueNode> nodes = [];

        public void addNode(DialogueNode node) {
            nodes.Add(node.Id, node);
        }

        public DialogueNode getNode(string nodeKey) {
            return nodes[nodeKey];
        }
    }
}