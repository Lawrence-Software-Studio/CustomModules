using System.Data;

namespace DialogueSystem {
    public class DialogueManager {
        private Dictionary<int, DialogueNode> _nodes = [];
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