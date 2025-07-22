using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueText {
        [JsonInclude]
        [JsonPropertyName("id")]
        private string _id = "";
        [JsonInclude]
        [JsonPropertyName("text")]
        private string _text = "";

        public DialogueText() {
        }

        public DialogueText(string id, string text) {
            _id = id;
            _text = text;
        }

        public string getId() {
            return _id;
        }

        public string getText() {
            return _text;
        }
    }
}