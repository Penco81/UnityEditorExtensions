using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class HierarchySample
{
    private static bool mCustomHierarchyEnabled = false;
    
        private const string PATH = "EditorExtension/Enable Custom Hierarchy";
        
        static HierarchySample()
        {
            Menu.SetChecked(PATH, mCustomHierarchyEnabled);
        }
        
        [MenuItem(PATH)]
        static void EnableCustomHierarchy()
        {
            if (mCustomHierarchyEnabled)
            {
                mCustomHierarchyEnabled = false;
                UnregisterHierarchy();
            }
            else
            {
                mCustomHierarchyEnabled = true;
                RegisterHierarchy();
            }
            Menu.SetChecked(PATH, mCustomHierarchyEnabled);
            
            EditorApplication.RepaintHierarchyWindow();
        }

        static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
            Debug.Log("Changed");
        }

        private static void OnHierarchyGUI(int instanceid, Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;

            if (obj)
            {
                var tagLabelRect = selectionrect;
                tagLabelRect.x += 100;
                GUI.Label(tagLabelRect, obj.tag);

                var layerLabelRect = tagLabelRect;
                layerLabelRect.x += 100;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            }
        }

        static void UnregisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
        }
}
