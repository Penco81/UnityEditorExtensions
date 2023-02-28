using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor.IMGUI.Controls;

public class OtherWindow : EditorWindow
{
    [MenuItem("EditorWindow/OtherWindow")]
    static void Open()
    {
        var window = GetWindow<OtherWindow>();
        window.position = new Rect(1000, 200, 800, 600);
        window.Show();
    }

    //可以拖拽实现更换顺序的list
    private ReorderableList mList;
    
    private List<Vector3> mData = new List<Vector3>();
    
    private TreeViewState mTreeViewState;
        
    private TreeViewSample mTreeViewSample;
    private SearchField mSearchField;
    private Vector2 mScrollPos;

    private void OnEnable()
    {
        mList = new ReorderableList(mData, typeof(Vector3));
        mList.elementHeight = 20;
        mList.drawHeaderCallback += DrawHeader;
        mList.drawNoneElementCallback += DrawNoneElement;
        mList.drawElementCallback += DrawElement;
        mList.drawElementBackgroundCallback += DrawElementBG;
        
        if (mTreeViewState == null)
        {
            mTreeViewState = new TreeViewState();
        }

        mTreeViewSample = new TreeViewSample(mTreeViewState);
        mSearchField = new SearchField();
        mSearchField.downOrUpArrowKeyPressed += mTreeViewSample.SetFocusAndEnsureSelectedItem;
    }
    
    private void OnGUI()
    {
        mScrollPos = EditorGUILayout.BeginScrollView(mScrollPos, GUILayout.MinHeight(400));
        mList.DoLayoutList();
        EditorGUILayout.EndScrollView();

        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.Space(100);
        GUILayout.FlexibleSpace();
        mTreeViewSample.searchString = mSearchField.OnToolbarGUI(mTreeViewSample.searchString);
        GUILayout.EndHorizontal();
        
        var rect = GUILayoutUtility.GetRect(0, 100000, 0, 100000);
        mTreeViewSample.OnGUI(rect);
    }
    
    private void DrawElementBG(Rect rect, int index, bool isactive, bool isfocused)
    {
        GUI.DrawTexture(rect, Texture2D.grayTexture);
    }

    private void DrawElement(Rect rect, int index, bool isactive, bool isfocused)
    {
        mData[index] = EditorGUI.Vector3Field(rect, "", mData[index]);
    }

    private void DrawNoneElement(Rect rect)
    {
        EditorGUI.HelpBox(rect, "None", MessageType.Info);
    }

    private void DrawHeader(Rect rect)
    {

        GUI.Box(rect, "header");
    }
    
    public class TreeViewSample : TreeView
    {
        public TreeViewSample(TreeViewState state) : base(state)
        {
            Reload();
        }
    
        protected override TreeViewItem BuildRoot()
        {
            var root = new TreeViewItem(0, -1, "Root");
                    
            var allItems = new List<TreeViewItem>()
            {
                new TreeViewItem(1, 0, "Animals"),
                new TreeViewItem(2, 1, "Mammals"),
                new TreeViewItem(3, 2, "Tiger"),
                new TreeViewItem(4, 2, "Elephant"),
                new TreeViewItem(5, 2, "Okapi"),
                new TreeViewItem(6, 2, "Armadillo"),
                new TreeViewItem(7, 1, "Reptiles"),
                new TreeViewItem(8, 2, "Crocodile"),
                new TreeViewItem(9, 2, "Lizard"),
                new TreeViewItem(10, 2, "Lizard2"),
                new TreeViewItem(11, 2, "Lizard3"),
                new TreeViewItem(12, 2, "Lizard4"),

            };
                    
            SetupParentsAndChildrenFromDepths(root,allItems);
    
            return root;
        }
    }
}


