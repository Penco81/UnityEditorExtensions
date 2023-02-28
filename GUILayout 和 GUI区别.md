Readme



## GUILayout 和 GUI区别

前者是自动布局，可自适应大小，后者是自定义布局，需要传入Rect参数表示控件的位置和大小。



## EditorGUILayout和EditorGUI区别

同上



## 以上四种的区别

GUI系列可用在MonoBehaviour的OnGUI函数里和编辑器窗口的函数里，

而Editor系列只能用于编辑器窗口里，但Editor系列包含了一些编辑器特有的API用来绘制特殊字段。



## GUIContent和GUIStyle区别

GUIContent决定渲染的内容：文本/图片/提示

GUIStyle决定渲染的样式：字体/颜色/背景/大小