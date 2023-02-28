using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//可以撤销的
public class UndoSample : MonoBehaviour
{

    static void APIs()
    {
        var newObj = new GameObject("Undo");
        Undo.RegisterCreatedObjectUndo(newObj,"CreateObj");
        
        var trans = Selection.activeGameObject.transform;
        if (trans)
        {
            Undo.RecordObject(trans,"MoveObj");
            trans.position += Vector3.up;
        }
        
        var selectedObj1 = Selection.activeGameObject;
        if (selectedObj1)
        {
            Undo.AddComponent(selectedObj1, typeof(Rigidbody));
        }
        
        var selectedObj2 = Selection.activeGameObject;
        if (selectedObj2)
        {
            Undo.DestroyObjectImmediate(selectedObj2);
        }
        
        var trans1 = Selection.activeGameObject.transform;
        var root = Camera.main.transform;
    
        if (trans1)
        {
            Undo.SetTransformParent(trans1, root, trans1.name);
        }
    }
}
