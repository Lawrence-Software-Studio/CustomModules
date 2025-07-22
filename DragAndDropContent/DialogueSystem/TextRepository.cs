using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class TextRepository {
        [JsonInclude]
        [JsonPropertyName("texts")]
        private Dictionary<string, string> _texts = [];

        public void addText(DialogueText text) {
            _texts.Add(text.Id, text.Text);
        }

        public string getText(string textKey) {
            return _texts[textKey];
        }
    }
}