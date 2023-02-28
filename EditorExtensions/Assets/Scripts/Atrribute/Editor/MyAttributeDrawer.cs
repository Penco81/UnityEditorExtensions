using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MyAttribute))]
public class MyAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.Label(new Rect(position.position,new Vector2(position.width,20)),"这个是使用了 My Attribute:" + property.intValue);

        EditorGUI.PropertyField(new Rect(position.x, position.y + 20, position.width, position.height - 20),
            property, label);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 20;
    }
}
