using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeGizmos : MonoBehaviour
{
    
    public Color mGizmosColor = Color.red;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = mGizmosColor;
        Gizmos.DrawCube(Vector3.zero, Vector3.one * 10);
    }

    //只有在对象被选择时，绘制Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = mGizmosColor;
        Gizmos.DrawSphere(Vector3.zero, 10);
    }
    
#if UNITY_EDITOR
    //DrawGizmo 属性可用于为任意 Component 提供辅助图标渲染器。
    [UnityEditor.DrawGizmo(UnityEditor.GizmoType.Active | UnityEditor.GizmoType.Selected)]
    private static void MyCustomOnDrawGizmos1(RuntimeGizmos target, UnityEditor.GizmoType gizmoType)
    {
        var color = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawCube(target.transform.position + Vector3.one,Vector3.one);
        Gizmos.color = color;
    }
#endif
}
