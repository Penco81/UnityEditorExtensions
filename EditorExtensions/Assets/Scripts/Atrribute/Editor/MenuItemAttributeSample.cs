using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class MenuItemAttributeSample
{
    private static bool isChecked = false;
    
    //必须为static
    [MenuItem("EditorExtension/Method1")]
    public static void Method1()
    {
        isChecked = !isChecked;
        //设置是否打勾
        Menu.SetChecked("EditorExtension/Method1", isChecked);
        Debug.Log("Method1");
    }
    
    //加入到GameObject的菜单中，默认优先级为1000（顶部和Hierarchy右击都能出现）
    [MenuItem("GameObject/Method2")]
    public static void Method2()
    {
        Debug.Log("Method2");
    }
    
    [MenuItem("EditorExtension/Method3")]
    public static void Method3()
    {
        Debug.Log("Method3");
    }
    
    //第二个参数，表示是否为验证函数，当返回值为true时，才能点击，否则置灰。验证函数的名字需要与被验证的MenuItem一样
    [MenuItem("EditorExtension/Method3", true)]
    public static bool ValidateMethod3()
    {
        return Selection.activeObject != null;
    }
    
    //加入快捷键
    [MenuItem("EditorExtension/Method4 %g")]
    public static void Method4()
    {
        Debug.Log("Method4");
    }
    
    //添加到Transform信息右侧三点点出的方法列表中
    [MenuItem("CONTEXT/Transform/Method5")]
    public static void DoubleMass(MenuCommand command)
    {
        Transform trans = (Transform)command.context;
        Debug.Log(trans.position);
    }
    
    //加入优先级，越低越偏上方，并且会根据优先级分组
    [MenuItem("EditorExtension/Method6", false, 0)]
    public static void Method6()
    {
        Debug.Log("Method6");
    }
    
    //优先级会分组，比上一个>=11会分组
    [MenuItem("EditorExtension/Method7", false, 11)]
    public static void Method7()
    {
        Debug.Log("Method7");
    }
    
    //添加到Asset右键出现的菜单中
    [MenuItem("Assets/Method8")]
    public static void Method8()
    {
        Debug.Log("Method8");
    }
    
    //代码执行MenuItem菜单
    [MenuItem("EditorExtension/Method9")]
    public static void Method9()
    {
        UnityEditor.EditorApplication.ExecuteMenuItem("Assets/Method8");
    }
}
