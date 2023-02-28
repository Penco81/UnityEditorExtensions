using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILayoutMode 
{
    private string mTextFieldValue = string.Empty;
    private string mTextAreaValue = string.Empty;
    private string mPasswordFieldValue = string.Empty;
    private Vector2 mScrollPosition = Vector2.zero;
    private float mSliderValue = 0.5f;
    private int mToolbarIndex;
    private bool mToggleValue;
    private int mSelectedGridIndex;
    private bool mToggleWindow;
    
    public void Draw()
    {
        GUILayout.Label("GUILayout Label");

        mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
        //新写法，结构化，作用域等
        {
            GUILayout.BeginVertical("Box");
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Text Field");
                    //GUILayout.FlexibleSpace();
                    mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                }
                GUILayout.EndHorizontal();
                
                GUILayout.Space(100);
                
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Text Area");
                    GUILayout.Space(100);
                    mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                }
                GUILayout.EndHorizontal();
                
                GUILayout.Space(100);
                
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Password Field");
                    mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                }
                GUILayout.EndHorizontal();
                
                GUILayout.Space(100);
                
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Button 1", GUILayout.Width(100), GUILayout.Height(100)))
                    {
                        Debug.Log("Button 1");
                    }
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Button 2", GUILayout.MinWidth(100), GUILayout.MaxWidth(200)
                            ,GUILayout.MinHeight(100), GUILayout.MaxHeight(200)))
                    {
                        Debug.Log("Button 2");
                    }
                    GUILayout.FlexibleSpace();
                    if (GUILayout.RepeatButton("RepeatButton"))
                    {
                        Debug.Log("RepeatButton");
                    }
                }
                GUILayout.EndHorizontal();
                
                GUILayout.Space(100);
                
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Box");
                    GUILayout.Box("AutoLayout Box");
                }
                GUILayout.EndHorizontal();
                
                GUILayout.Space(100);

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Slider");
                    mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 1);
                    //mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                }
                GUILayout.EndHorizontal();
                
                mSliderValue = GUILayout.HorizontalScrollbar(mSliderValue, 4, 0, 1);

                GUILayout.BeginArea(new Rect(100,100,200,200));
                {
                    GUILayout.Label("Area");
                }
                GUILayout.EndArea();
                
                GUILayout.Space(100);
                
                mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new string[]
                {
                    "1", "2", "3", "4", "5"
                });

                mSelectedGridIndex = GUILayout.SelectionGrid(mSelectedGridIndex, new string[]
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5"
                }, 3);
                
                //好像无用
                mToggleWindow = GUILayout.Toggle(mToggleWindow, "Window");
                if (mToggleWindow)
                {
                    GUILayout.Window(0, new Rect(1000, 1000, 200, 200), id =>
                    {
                        GUILayout.Label("Window");
                    }, "window");
                }

            }
            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();
    }
}
