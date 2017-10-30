using UnityEngine;
using UnityEditor;

namespace VST.Editor
{
    public class EditorMain : EditorWindow
    {
        public static EditorMain instance;

        int selected;
        float currentScrollViewWidth;
        private Vector2 scrollPos = Vector2.zero;
        Rect cursorChangeRect;
        bool resize = false;

        public static void OpenVST()
        {
            instance = (EditorMain)EditorWindow.GetWindow(typeof(EditorMain));
            instance.titleContent = new GUIContent("VST");
            instance.Show();
        }
        private void OnEnable()
        {
            currentScrollViewWidth = this.position.width / 3;
            cursorChangeRect = new Rect(currentScrollViewWidth, 0, 2f, this.position.height);
        }

        private void OnDisable() { Debug.Log("OnDisable called"); }
        private void OnDestroy() { Debug.Log("OnDestroy called"); }
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(currentScrollViewWidth));

            selected = GUILayout.SelectionGrid(selected, new string[] { "이벤트", "동작", "형태", "데이터", "연산", "제어", "관찰", "소리", "비디오" }, 2, "PreferencesKeysElement");
            //Debug.Log("selected : " + selected);

            GUILayout.EndScrollView();

            ResizeScrollView();

            GUILayout.FlexibleSpace();
            GUILayout.Label("Lower part");

            GUILayout.EndHorizontal();

            Repaint();
        }

        private void ResizeScrollView()
        {
            GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
            EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeHorizontal);

            if (Event.current.type == EventType.mouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
            {
                resize = true;
            }
            if (resize)
            {
                currentScrollViewWidth = Event.current.mousePosition.x;
                //cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, cursorChangeRect.height);
                cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, this.position.height);
            }
            if (Event.current.type == EventType.MouseUp)
                resize = false;
        }

    }
}