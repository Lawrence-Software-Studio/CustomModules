using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class TextRepository {
        [JsonInclude]
        [JsonPropertyName("texts")]
        private DialogueText[] _texts = [];

        public TextRepository() {
        }

        public TextRepository(int size) {
            _texts = new DialogueText[size];
        }

        public void setText(int id, DialogueText text) {
            _texts[id] = text;
        }

        public string getText(int id) {
            return _texts[id].getText();
        }
    }
}