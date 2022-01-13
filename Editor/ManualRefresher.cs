using UnityEditor;

namespace ManualRefresher.Editor
{
    [InitializeOnLoad]
    public class ManualRefresher
    {
        static ManualRefresher()
        {
            EditorApplication.playModeStateChanged += OnStateChanged;
        }

        [MenuItem("Tools/Manual Refresh #c", priority = 1)]
        public static void Refresh()
        {
            AssetDatabase.Refresh(ImportAssetOptions.Default);
        }

        private static void OnStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingEditMode)
            {
                Refresh();
            }
        }
    }
}