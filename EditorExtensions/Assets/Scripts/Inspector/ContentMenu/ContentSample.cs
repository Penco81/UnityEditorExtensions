using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ContentSample : MonoBehaviour
{
    [ContextMenu("ContextMenu Button")]
    void ContextButton()
    {
        Debug.Log("ContextButton");
    }

    [ContextMenuItem("Print Value","PrintValue")]
    public string mContextMenuItemValue;
    
    void PrintValue()
    {
        Debug.Log(mContextMenuItemValue);
    }

    [MenuItem("CONTEXT/ContentSample/ContextByMenuItem")]
    static void ContextByMenuItem()
    {
        Debug.Log("ContextByMenuItem");
    }
}
