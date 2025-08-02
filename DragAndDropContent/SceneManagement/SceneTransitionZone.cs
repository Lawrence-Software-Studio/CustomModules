using Godot;

namespace SceneManagement {
    public partial class SceneTransitionZone : Area2D {
        [Export] private Vector2 PlayerSpawnPosition;
        [Export] private SceneName ChangeToScene;

        public override void _Ready() {
            base._Ready();
            BodyEntered += (body) => CallDeferred("ChangeScene", [body]);
        }

        private void ChangeScene(Node2D body) {
            SceneManager.ChangeTo = SceneNameUtil.EnumToFilePath[ChangeToScene];
            SceneManager.SpawnPoint = PlayerSpawnPosition;
            GetTree().ChangeSceneToFile(SceneManager.ChangeTo);
        }
    }
}
