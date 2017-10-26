using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

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

        GUIStyle style_textSize_16 = new GUIStyle();

        public static void OpenVST()
        {
            instance = (EditorMain)EditorWindow.GetWindow(typeof(EditorMain));
            instance.titleContent = new GUIContent("VST");
            instance.Show();
        }
        private void OnEnable()
        {
            style_textSize_16.fontSize = 16;
            style_textSize_16.margin = new RectOffset( 10, 10, 10, 10 );

            //currentScrollViewWidth = this.position.width / 3;
            currentScrollViewWidth = this.position.width;
            Debug.Log("this.position.width : " + this.position.width);
            cursorChangeRect = new Rect(currentScrollViewWidth, 0, 2f, this.position.height);
        }

        private void OnDisable() { /*Debug.Log("OnDisable called");*/ }
        private void OnDestroy() { /*Debug.Log("OnDestroy called");*/ }
        private void OnGUI()
        {
            //Rect r = EditorGUILayout.BeginHorizontal("Box");
            Rect r = EditorGUILayout.BeginHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(currentScrollViewWidth));

            selected = GUILayout.SelectionGrid(selected, new string[] { "이벤트", "동작", "형태", "데이터", "연산", "제어", "관찰", "소리", "비디오" }, 2, "PreferencesKeysElement");
            //Debug.Log("selected : " + selected);
            EditorGUILayout.BeginVertical("Window");
            //GUILayout.Label("Lower part");
            ChangeBlockList(selected);
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

            ResizeScrollView();
            EditorGUILayout.BeginHorizontal("Window");
            //GUILayout.FlexibleSpace();
            
            GUILayout.Label("블록 코딩 영역", style_textSize_16);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndHorizontal();

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
        private void ChangeBlockList(int _i)
        {
            switch (_i)
            {
                //이벤트.
                case 0:
                    if (GUILayout.Button("Awake", style_textSize_16)) { Debug.Log("-- Awake"); }
                    if (GUILayout.Button("Start", style_textSize_16)) { Debug.Log("-- Start"); }
                    if (GUILayout.Button("Update", style_textSize_16)) { Debug.Log("-- Update"); }
                    if (GUILayout.Button("FixedUpdate", style_textSize_16)) { Debug.Log("-- FixedUpdate"); }
                    if (GUILayout.Button("LateUpdate", style_textSize_16)) { Debug.Log("-- LateUpdate"); }
                    if (GUILayout.Button("OnEnable", style_textSize_16)) { Debug.Log("-- OnEnable"); }
                    if (GUILayout.Button("OnDisable", style_textSize_16)) { Debug.Log("-- OnDisable"); }
                    if (GUILayout.Button("OnDestory", style_textSize_16)) { Debug.Log("-- OnDestory"); }
                    break;
                //동작.
                case 1:
                    if (GUILayout.Button("동작 항목 0", style_textSize_16)) { Debug.Log("-- 동작 항목 0"); }
                    if (GUILayout.Button("동작 항목 1", style_textSize_16)) { Debug.Log("-- 동작 항목 1"); }
                    if (GUILayout.Button("동작 항목 2", style_textSize_16)) { Debug.Log("-- 동작 항목 2"); }
                    break;
                //형태.
                case 2:
                    if (GUILayout.Button("형태 항목 0", style_textSize_16)) { Debug.Log("-- 형태 항목 0"); }
                    if (GUILayout.Button("형태 항목 1", style_textSize_16)) { Debug.Log("-- 형태 항목 1"); }
                    if (GUILayout.Button("형태 항목 2", style_textSize_16)) { Debug.Log("-- 형태 항목 2"); }
                    if (GUILayout.Button("형태 항목 3", style_textSize_16)) { Debug.Log("-- 형태 항목 3"); }
                    break;
                //데이터.
                case 3:
                    if (GUILayout.Button("Variable", style_textSize_16)) { Debug.Log("Variable"); }
                    if (GUILayout.Button("Array", style_textSize_16)) { Debug.Log("Array"); }
                    break;
                //연산.
                case 4:
                    if (GUILayout.Button("a + b", style_textSize_16)) { Debug.Log("a + b"); }
                    if (GUILayout.Button("a - b", style_textSize_16)) { Debug.Log("a - b"); }
                    if (GUILayout.Button("a * b", style_textSize_16)) { Debug.Log("a * b"); }
                    if (GUILayout.Button("a / b", style_textSize_16)) { Debug.Log("a / b"); }
                    if (GUILayout.Button("random", style_textSize_16)) { Debug.Log("random"); }
                    if (GUILayout.Button("a > b", style_textSize_16)) { Debug.Log("a > b"); }
                    if (GUILayout.Button("a >= b", style_textSize_16)) { Debug.Log("a >= b"); }
                    if (GUILayout.Button("a == b", style_textSize_16)) { Debug.Log("a == b"); }
                    if (GUILayout.Button("a != b", style_textSize_16)) { Debug.Log("a != b"); }
                    if (GUILayout.Button("a < b", style_textSize_16)) { Debug.Log("a < b"); }
                    if (GUILayout.Button("a <= b", style_textSize_16)) { Debug.Log("a <= b"); }
                    if (GUILayout.Button("a && b", style_textSize_16)) { Debug.Log("a && b"); }
                    if (GUILayout.Button("a || b", style_textSize_16)) { Debug.Log("a || b"); }
                    break;
                //제어.
                case 5:
                    if (GUILayout.Button("if", style_textSize_16)) { Debug.Log("if"); }
                    if (GUILayout.Button("if else", style_textSize_16)) { Debug.Log("if else"); }
                    if (GUILayout.Button("switch", style_textSize_16)) { Debug.Log("switch"); }
                    if (GUILayout.Button("for", style_textSize_16)) { Debug.Log("for"); }
                    if (GUILayout.Button("while", style_textSize_16)) { Debug.Log("while"); }
                    break;
                //관찰.
                case 6:
                    if (GUILayout.Button("관찰 항목 0", style_textSize_16)) { Debug.Log("-- 관찰 항목 0"); }
                    if (GUILayout.Button("관찰 항목 1", style_textSize_16)) { Debug.Log("-- 관찰 항목 1"); }
                    if (GUILayout.Button("관찰 항목 2", style_textSize_16)) { Debug.Log("-- 관찰 항목 2"); }
                    if (GUILayout.Button("관찰 항목 3", style_textSize_16)) { Debug.Log("-- 관찰 항목 3"); }
                    break;
                //소리.
                case 7:
                    if (GUILayout.Button("소리 항목 0", style_textSize_16)) { Debug.Log("-- 소리 항목 0"); }
                    if (GUILayout.Button("소리 항목 1", style_textSize_16)) { Debug.Log("-- 소리 항목 1"); }
                    if (GUILayout.Button("소리 항목 2", style_textSize_16)) { Debug.Log("-- 소리 항목 2"); }
                    break;
                //비디오.
                case 8:
                    if (GUILayout.Button("비디오 항목 0", style_textSize_16)) { Debug.Log("-- 비디오 항목 0"); }
                    if (GUILayout.Button("비디오 항목 1", style_textSize_16)) { Debug.Log("-- 비디오 항목 1"); }
                    if (GUILayout.Button("비디오 항목 2", style_textSize_16)) { Debug.Log("-- 비디오 항목 2"); }
                    if (GUILayout.Button("비디오 항목 3", style_textSize_16)) { Debug.Log("-- 비디오 항목 3"); }
                    break;
            }
        }
    }
}