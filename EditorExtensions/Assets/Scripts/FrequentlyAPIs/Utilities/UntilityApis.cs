using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UntilityApis
{
    //伪代码
    static void APIs()
    {
        EditorUtility.DisplayProgressBar("DisplayProgressBar", "info", 0.5f);
        EditorUtility.ClearProgressBar();
        
        bool sure = EditorUtility.DisplayDialog("DisplayDialog","message","ok","cancel");

        //预留一个矩形大小
        GUILayoutUtility.GetRect (200, 100);
        //获取最近绘制的矩形大小
        var rect1 = GUILayoutUtility.GetLastRect();
        //预留固定比例的矩形
        var rect2 = GUILayoutUtility.GetAspectRect(0.5f);

        var GameObject = new GameObject();
        //移除丢失的脚本
        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(GameObject);
        
        //HandleUtility主要提供了一些算法，如各种距离计算方法以及物体选择的方法。
        //GUIUtility 提供GUI位置到屏幕空间的转换

        Vector3[] positions = new Vector3[2];
        Transform transform = null;
        //根据给定的位置数组和转换矩阵计算边界框。
        Bounds bounds = GeometryUtility.CalculateBounds(positions, transform.localToWorldMatrix);

        Camera cam = null;
        //输入相机，返回相机视锥体的六个平面，是一个Plane[]
        //顺序为: [0] = Left, [1] = Right, [2] = Down, [3] = Up, [4] = Near, [5] = Far
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        Collider objCollider = null;
        //如果边界框在平面内或与任意平面相交，则返回true。
        //TestPlanesAABB函数使用平面数组来测试边界框是否位于截锥体中。
        //可以使用这个函数和CalculateFrustumPlanes一起测试一个摄像头的视图是否包含一个对象，
        //不管它是否被渲染。
        GeometryUtility.TestPlanesAABB(planes, objCollider.bounds);

        Plane plane;
        //从定义多边形的给定顶点列表创建一个平面，只要它们不表示直线或零区域。
        //必须有至少三个顶点来创建平面;零，一个或两个顶点导致false返回没有平面。
        //这适用于凹多边形和具有多个对齐顶点的多边形，但不适用于自交多边形。
        GeometryUtility.TryCreatePlaneFromPolygon(positions, out plane);
    }
}
