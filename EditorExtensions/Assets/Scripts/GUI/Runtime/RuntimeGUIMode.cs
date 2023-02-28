using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeGUIMode : MonoBehaviour
{
    private GUIMode mGUIMode = new GUIMode();

    private void OnGUI()
    {
        mGUIMode.Draw();
    }
}
