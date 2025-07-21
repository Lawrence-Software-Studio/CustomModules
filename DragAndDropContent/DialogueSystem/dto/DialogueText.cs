using System.Text.Json.Serialization;

namespace DialogueSystem {
    public class DialogueText {
        [JsonPropertyName("id")]
        public readonly int Id;
        [JsonPropertyName("text")]
        public readonly string Text;

        [JsonConstructor]
        public DialogueText(int id, string text) {
            Id = id;
            Text = text;
        }
    }
}