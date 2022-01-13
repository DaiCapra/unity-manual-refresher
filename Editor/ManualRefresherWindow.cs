using UnityEditor;
using UnityEngine;

namespace ManualRefresher.Editor
{
    public class ManualRefresherWindow : EditorWindow
    {
        private const string AutoRefresh = "kAutoRefresh";
        private const string DirectoryMonitoring = "DirectoryMonitoring";
        public bool autoRefresh;
        private bool _initialized;

        internal void OnGUI()
        {
            if (!_initialized)
            {
                _initialized = true;
                autoRefresh = EditorPrefs.GetBool(AutoRefresh) || EditorPrefs.GetBool(DirectoryMonitoring);
            }

            EditorGUILayout.BeginVertical();

            var temp = autoRefresh;
            autoRefresh = EditorGUILayout.Toggle("Pref.->Auto Refresh", autoRefresh);

            var hasChanged = autoRefresh != temp;
            if (hasChanged)
            {
                SetAutoRefresh(autoRefresh);
            }

            if (GUILayout.Button("Refresh"))
            {
                ManualRefresher.Refresh();
            }

            EditorGUILayout.EndVertical();
        }

        [MenuItem("Tools/Manual Refresher Window")]
        internal static void Init()
        {
            var window = (ManualRefresherWindow) GetWindow(typeof(ManualRefresherWindow), false, "Manual Refresher");
            window.position = new Rect(window.position.xMin + 100f, window.position.yMin + 100f, 200f, 100f);
        }

        
        private void SetAutoRefresh(bool isEnabled)
        {
            EditorPrefs.SetBool(AutoRefresh, isEnabled);
            EditorPrefs.SetBool(DirectoryMonitoring, isEnabled);
        }
    }
}