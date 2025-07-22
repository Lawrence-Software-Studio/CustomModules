using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueText {
        [JsonInclude]
        [JsonPropertyName("id")]
        private int _id;
        [JsonInclude]
        [JsonPropertyName("text")]
        private string _text = "";

        public DialogueText() {
        }

        public DialogueText(int id, string text) {
            _id = id;
            _text = text;
        }

        public int getId() {
            return _id;
        }

        public string getText() {
            return _text;
        }
    }
}