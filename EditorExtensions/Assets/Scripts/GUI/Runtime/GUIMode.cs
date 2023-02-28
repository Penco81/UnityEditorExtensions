using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMode
{
    private Rect mLabelRect = new Rect(20, 60, 200, 20);
    private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
    private Rect mTextAreaRect = new Rect(20, 120, 200, 100);
    private Rect mPasswordFieldRect = new Rect(20, 240, 200, 20);
    private Rect mButtonRect = new Rect(20, 270, 200, 20);
    private Rect mRepeatButtonRect = new Rect(20, 300, 200, 20);
    private Rect mToggleRect = new Rect(20, 330, 200, 20);
    private Rect mToolbarRect = new Rect(20, 360, 400, 20);
    private Rect mBoxRect = new Rect(20, 400, 100, 100);
    private Rect mHorizontalSliderRect = new Rect(20, 500, 100, 20);
    private Rect mVerticalSliderRect = new Rect(20, 530, 20, 100);
    private Rect mGroupRect = new Rect(20, 630, 100, 20);
    private Rect mWindowRect = new Rect(20, 660, 100, 100);
    
    private string mTextFieldValue = "defalut";
    private string mTextAreaValue = "defalut";
    private string mPasswordFieldValue = "defalut";
    private bool mToggleValue;
    private int mToolbarIndex;
    private float mSliderValue;
        
    private Vector2 mScrollPos = Vector2.zero;
    
    public void Draw()
    {
        //位置，滑动位置，视口大小
        //好像是无效的
        mScrollPos = GUI.BeginScrollView(new Rect(20, 0, 400, 500), mScrollPos, new Rect(0,0,400,500));
        GUI.EndScrollView();
        GUI.Label(mLabelRect, "Label Rect");
        //输入区域，默认值
        mTextFieldValue = GUI.TextField(mTextFieldRect, mTextFieldValue);
        mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);
        //最后一个参数为显示的字符
        mPasswordFieldValue = GUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue, '#');

        //Button的第二个参数可以用Texture来代替
        //只有在松开的时候触发
        if (GUI.Button(mButtonRect, "Button"))
        {
            Debug.Log("Button Clicked");
        }

        //点击和松开的时候都会触发
        if (GUI.RepeatButton(mRepeatButtonRect, "Repeated Button"))
        {
            Debug.Log("Repeated Button");
        }

        //选择框
        mToggleValue = GUI.Toggle(mToggleRect, mToggleValue, "Toggle");
        //多选项的选择框
        mToolbarIndex = GUI.Toolbar(mToolbarRect, mToolbarIndex, new string[] {"1","2","3"});

        //滑动的值
        mSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mSliderValue, 0, 1);
        mSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mSliderValue, 0, 1);
        
        GUI.Box(mBoxRect, "Box!");
        
        //Group范围内的控件位置为相对于Group的位置
        //好像有问题
        GUI.BeginGroup(mGroupRect, "Group");
        GUI.Box(new Rect(100, 100, 400, 200), "Box In Group!");
        GUI.EndGroup();
        //好像也无用
        GUI.Window(0, mWindowRect, (windowId) =>
        {
            Debug.Log("Open Window");
        }, "window");
    }
}
