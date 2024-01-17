using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ExtensionUtils
{
    #region EDITOR MENU UNITY
    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Minhas Funções/A %a")]

    public static void A()
    {
        Debug.Log("A Executada");
    }

    [UnityEditor.MenuItem("Minhas Funções/B %g")]

    public static void B()
    {
        Debug.Log("B Executada");
    }

    #endif
    #endregion

    #region  FUNCOES MISTAS

    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static T GetRandom<T> (this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    #endregion
}
