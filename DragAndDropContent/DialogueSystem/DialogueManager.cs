using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueManager {
        [JsonInclude]
        [JsonPropertyName("nodes")] // do we want each character to have their own tree?
        private Dictionary<int, DialogueNode> _nodes = [];
        [JsonInclude]
        [JsonPropertyName("texts")] // Remove this later if we want to separate text from node file
        private Dictionary<int, string> _texts = [];

        public void addNode(DialogueNode node) {
            _nodes.Add(node.Id, node);
        }

        public void addText(DialogueText text) {
            _texts.Add(text.Id, text.Text);
        }

        public DialogueNode getNode(int nodeKey) {
            return _nodes[nodeKey];
        }

        public string getText(int textKey) {
            return _texts[textKey];
        }
    }
}