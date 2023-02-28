using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//绘制在inspector的底部
[CustomPreview(typeof(GameObject))]
public class ObjectPreviewSample : ObjectPreview
{
    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        GUI.Label(r,target.name + "正在被预览");
    }
}
