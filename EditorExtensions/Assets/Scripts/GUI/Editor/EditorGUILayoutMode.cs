using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class EditorGUILayoutMode
{
    private BuildTargetGroup mBuildTargetGroupValue;

    //从 0 到 1 的 lerp。
    //当值为 0 时返回 false，当值大于 0.5 时返回 true。
    private AnimBool mAnimBool = new AnimBool(false);
        

    private bool mFoldOutGroup = false;

    private bool mGroupValue = false;
    private bool mToggle1Value = false;
    private bool mToggle2Value = true;
    private string mTextField;
    private bool foldInspector = false;
    
    public void Draw()
    {
        mAnimBool.target = EditorGUILayout.ToggleLeft("Open Fade Group", mAnimBool.target);
        //创建左侧带有折叠箭头的标签
        mFoldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(mFoldOutGroup, "FoldOut");
        {
            if (mFoldOutGroup)
            {
                //开始一个可隐藏/显示的组，并且过渡将生成动画。
                EditorGUILayout.BeginFadeGroup(mAnimBool.faded);
                {
                    if (mAnimBool.target)
                    {
                        //开始构建目标组并返回所选 BuildTargetGroup
                        mBuildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();

                        EditorGUILayout.EndBuildTargetSelectionGrouping();
                    }
                }
                EditorGUILayout.EndFadeGroup();
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        
        //开始一个垂直组，带有可一次性启用或禁用所有控件的开关。
        mGroupValue = EditorGUILayout.BeginToggleGroup("Toggle Group", mGroupValue);
        mTextField = EditorGUILayout.TextField(mTextField);
        mToggle1Value = EditorGUILayout.Toggle(mToggle1Value);
        mToggle2Value = EditorGUILayout.Toggle(mToggle2Value);

        EditorGUILayout.EndToggleGroup();

        if (Selection.activeGameObject)
        {
            Transform selectedTransform = Selection.activeGameObject.transform;
            MeshRenderer meshRender = Selection.activeGameObject.GetComponent<MeshRenderer>();
            
            //创建一个类似于 Inspector 窗口的标题栏。
            foldInspector = EditorGUILayout.InspectorTitlebar(foldInspector, selectedTransform);
            if (foldInspector)
            {
                selectedTransform.position =
                    EditorGUILayout.Vector3Field("Position", selectedTransform.position);
            }
            foldInspector = EditorGUILayout.InspectorTitlebar(foldInspector, meshRender);
            if (foldInspector)
            {
                
            }
        }
    }
}
