using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSamples : MonoBehaviour
{
    public int Age;

    [HideInInspector]
    public int Age1;

    [Header("年龄")]
    [SerializeField]
    private int Age2;

    [Space(20)]
    public int Age3;

    [Multiline(5)]
    public string Comment;

    [TextArea]
    public string Comment1;

    [Range(5, 10)] public int Age4;

    [My]
    public int Age5;
}
