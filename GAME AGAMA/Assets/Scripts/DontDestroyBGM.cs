using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    public static DontDestroyBGM instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }
}
