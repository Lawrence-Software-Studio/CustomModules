using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class TextRepository {
        [JsonInclude]
        [JsonPropertyName("texts")]
        private Dictionary<string, DialogueText> _texts = [];

        public void addText(DialogueText text) {
            _texts.Add(text.getId(), text);
        }

        public string getText(string textKey) {
            return _texts[textKey].getText();
        }
    }
}