using UnityEditor;

namespace VST.Editor {
	public static class MenuItems {
        //[MenuItem("비주얼스크립트 / Open VST _#v")]
        [MenuItem("비주얼스크립트 / Open VST")]
        private static void OpenVST () {
            EditorMain.OpenVST();
		}
	}
}