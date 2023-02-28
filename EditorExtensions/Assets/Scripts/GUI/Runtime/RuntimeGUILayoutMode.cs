using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeGUILayoutMode : MonoBehaviour
{
    private GUILayoutMode mGUILayout = new GUILayoutMode();

    private void OnGUI()
    {
        mGUILayout.Draw();
    }
}
