using System.Collections.Generic;

namespace SceneManagement {
    public enum SceneName {
        ExampleSceneA = 0,
        ExampleSceneB = 1,
    }

    public class SceneNameUtil {
        public static readonly Dictionary<SceneName, string> EnumToFilePath = new Dictionary<SceneName, string> {
            {SceneName.ExampleSceneA, "res://throwaway/ExampleSceneA.tscn"},
            {SceneName.ExampleSceneB, "res://throwaway/ExampleSceneB.tscn"},
        };
    }
}