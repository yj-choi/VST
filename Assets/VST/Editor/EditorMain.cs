using UnityEngine;
using UnityEditor;

namespace VST.Editor
{
    public class EditorMain : EditorWindow
    {
        public static EditorMain instance;
        // 스타일들.
        private GUIStyle style_textSize_16 = new GUIStyle();

        // 선택된 대분류 번호.
        private int selected;
        // 스크롤뷰 너비.
        private float currentScrollViewWidth;
        // 스크롤뷰 시작 위치.
        private Vector2 scrollPos = Vector2.zero;
        // 영역구분막대.
        private Rect cursorChangeRect;
        // 스크롤뷰 크기변경 플래그.
        private bool isResizeScrollView = false;
        // 블록 배열.
        //private List<DataObject> m_Data = new List<DataObject>();
        // 화면 갱신 플래그.
        private bool doRepaint = false;
        //---------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------
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
        void Update()
        {
            if (doRepaint)
            {
                Repaint();
            }
        }
        private void OnGUI()
        {
            //Rect r = EditorGUILayout.BeginHorizontal("Box");
            //Rect r = EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(currentScrollViewWidth));

            //selected = GUILayout.SelectionGrid(selected, new string[] { "이벤트", "동작", "형태", "데이터", "연산", "제어", "관찰", "소리", "비디오" }, 2, "PreferencesKeysElement");
            selected = GUILayout.SelectionGrid(selected, new string[] { "이벤트", "동작", "형태", "데이터", "연산", "제어", "관찰", "소리", "비디오" }, 2, "PreferencesKeysElement");

            EditorGUILayout.BeginVertical("Window");
            ChangeBlockList(selected);
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

            ResizeScrollView();
            EditorGUILayout.BeginHorizontal("Window");
            //GUILayout.FlexibleSpace();
            
            GUILayout.Label("블록 코딩 영역", style_textSize_16);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndHorizontal();

            //Rect rb = EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("설정")) { Debug.Log("설정 button pressed"); }
            if (GUILayout.Button("컴파일")) { Debug.Log("컴파일 button pressed"); }
            if (GUILayout.Button("코드 적용")) { Debug.Log("코드 적용 button pressed"); }
            EditorGUILayout.EndHorizontal();

            Repaint();
        }

        private void ResizeScrollView()
        {
            GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
            EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeHorizontal);

            if (Event.current.type == EventType.mouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
            {
                isResizeScrollView = true;
            }
            if (isResizeScrollView)
            {
                currentScrollViewWidth = Event.current.mousePosition.x;
                //cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, cursorChangeRect.height);
                cursorChangeRect.Set(currentScrollViewWidth, cursorChangeRect.y, cursorChangeRect.width, this.position.height);
            }
            if (Event.current.type == EventType.MouseUp)
                isResizeScrollView = false;
        }
        private void ChangeBlockList(int _i)
        {
            switch (_i)
            {
                //이벤트.
                case 0:
                    if (GUILayout.Button("Awake", style_textSize_16)) { Debug.Log("Awake"); }
                    if (GUILayout.Button("Start", style_textSize_16)) { Debug.Log("Start"); }
                    if (GUILayout.Button("Update", style_textSize_16)) { Debug.Log("Update"); }
                    if (GUILayout.Button("FixedUpdate", style_textSize_16)) { Debug.Log("FixedUpdate"); }
                    if (GUILayout.Button("LateUpdate", style_textSize_16)) { Debug.Log("LateUpdate"); }
                    if (GUILayout.Button("OnEnable", style_textSize_16)) { Debug.Log("OnEnable"); }
                    if (GUILayout.Button("OnDisable", style_textSize_16)) { Debug.Log("OnDisable"); }
                    if (GUILayout.Button("OnDestory", style_textSize_16)) { Debug.Log("OnDestory"); }
                    break;
                //동작.
                case 1:
                    if (GUILayout.Button("동작 항목 0", style_textSize_16)) { Debug.Log("동작 항목 0"); }
                    if (GUILayout.Button("동작 항목 1", style_textSize_16)) { Debug.Log("동작 항목 1"); }
                    if (GUILayout.Button("동작 항목 2", style_textSize_16)) { Debug.Log("동작 항목 2"); }
                    break;
                //형태.
                case 2:
                    if (GUILayout.Button("형태 항목 0", style_textSize_16)) { Debug.Log("형태 항목 0"); }
                    if (GUILayout.Button("형태 항목 1", style_textSize_16)) { Debug.Log("형태 항목 1"); }
                    if (GUILayout.Button("형태 항목 2", style_textSize_16)) { Debug.Log("형태 항목 2"); }
                    if (GUILayout.Button("형태 항목 3", style_textSize_16)) { Debug.Log("형태 항목 3"); }
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
                    if (GUILayout.Button("a AND b", style_textSize_16)) { Debug.Log("a AND b"); }
                    if (GUILayout.Button("a OR b", style_textSize_16)) { Debug.Log("a OR b"); }
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
                    if (GUILayout.Button("관찰 항목 0", style_textSize_16)) { Debug.Log("관찰 항목 0"); }
                    if (GUILayout.Button("관찰 항목 1", style_textSize_16)) { Debug.Log("관찰 항목 1"); }
                    if (GUILayout.Button("관찰 항목 2", style_textSize_16)) { Debug.Log("관찰 항목 2"); }
                    if (GUILayout.Button("관찰 항목 3", style_textSize_16)) { Debug.Log("관찰 항목 3"); }
                    break;
                //소리.
                case 7:
                    if (GUILayout.Button("소리 항목 0", style_textSize_16)) { Debug.Log("소리 항목 0"); }
                    if (GUILayout.Button("소리 항목 1", style_textSize_16)) { Debug.Log("소리 항목 1"); }
                    if (GUILayout.Button("소리 항목 2", style_textSize_16)) { Debug.Log("소리 항목 2"); }
                    break;
                //비디오.
                case 8:
                    if (GUILayout.Button("비디오 항목 0", style_textSize_16)) { Debug.Log("비디오 항목 0"); }
                    if (GUILayout.Button("비디오 항목 1", style_textSize_16)) { Debug.Log("비디오 항목 1"); }
                    if (GUILayout.Button("비디오 항목 2", style_textSize_16)) { Debug.Log("비디오 항목 2"); }
                    if (GUILayout.Button("비디오 항목 3", style_textSize_16)) { Debug.Log("비디오 항목 3"); }
                    break;
            }
        }
    }
}