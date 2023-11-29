using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour
{
    [MenuItem("My Custom Menu/Hello World!")]
    private static void HelloWorld() {
        Debug.Log("Hello World!");
    }
}
