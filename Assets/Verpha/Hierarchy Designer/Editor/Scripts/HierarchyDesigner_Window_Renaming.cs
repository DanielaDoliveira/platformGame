#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Verpha.HierarchyDesigner
{
    public class HierarchyDesigner_Window_Renaming : EditorWindow
    {
        #region OnGUI Properties
        private Vector2 scrollPosition;
        private static Vector2 lastMainWindowSize;
        private GUIContent hierarchyLabelContent;
        #endregion
        #region General Properties
        private static string newName;
        private static GameObject[] selectedGameObjects;
        private static bool autoIncrementation = true;
        #endregion

        public static void OpenWindow(GameObject[] gameObjects, Vector2 position, bool autoIndex = true)
        {
            HierarchyDesigner_Window_Renaming window = GetWindow<HierarchyDesigner_Window_Renaming>("Hierarchy Designer Renaming");
            Vector2 size = new Vector2(400, 115);
            window.minSize = size;

            autoIncrementation = autoIndex;
            Rect mainWindowRect = EditorGUIUtility.GetMainWindowPosition();
            if (mainWindowRect.size != lastMainWindowSize)
            {
                lastMainWindowSize = mainWindowRect.size;
                Vector2 centerPoint = new Vector2(
                    (mainWindowRect.width - size.x) * 0.5f,
                    (mainWindowRect.height - size.y) * 0.5f
                );
                window.position = new Rect(centerPoint, size);
            }
            window.hierarchyLabelContent = new GUIContent("Rename Selected GameObjects");
            selectedGameObjects = gameObjects;
            newName = "";
        }

        private void OnGUI()
        {
            GUIStyle customSettingsStyle = HierarchyDesigner_Info_OnGUI.CreateCustomStyle();
            GUILayout.BeginVertical(customSettingsStyle);
            GUILayout.Space(5);

            GUILayout.Label(hierarchyLabelContent, EditorStyles.boldLabel);
            GUILayout.Space(5);
            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            autoIncrementation = EditorGUILayout.Toggle("Use Auto Index", autoIncrementation);
            newName = EditorGUILayout.TextField("New Name", newName);
            
            GUILayout.Space(5);
            if (GUILayout.Button("Rename", GUILayout.Height(25)))
            {
                ApplyNewNameToSelectedObjects();
                Close();
            }
            EditorGUILayout.EndScrollView();
            GUILayout.EndVertical();
        }

        private static void ApplyNewNameToSelectedObjects()
        {
            for (int i = 0; i < selectedGameObjects.Length; i++)
            {
                if (selectedGameObjects[i] != null)
                {
                    Undo.RecordObject(selectedGameObjects[i], "Rename GameObject");
                    string objectName = autoIncrementation ? $"{newName} ({i + 1})" : newName;
                    selectedGameObjects[i].name = objectName;
                    EditorUtility.SetDirty(selectedGameObjects[i]);
                }
            }
        }

        private void OnDestroy()
        {
            newName = null;
            selectedGameObjects = null;
        }
    }
}
#endif