using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueText {
        [JsonPropertyName("id")]
        public readonly string Id;
        [JsonPropertyName("text")]
        public readonly string Text;

        [JsonConstructor]
        public DialogueText(string id, string text) {
            Id = id;
            Text = text;
        }
    }
}