using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThis : MonoBehaviour
{
    #region Singleton

    public static DontDestroyThis instance;

    private void Awake()
    {
        instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("themeMusic");
        if (objs.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
}
