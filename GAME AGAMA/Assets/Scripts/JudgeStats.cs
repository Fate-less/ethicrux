using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JudgeStats : MonoBehaviour
{
    public int trust;
    public int conscience;
    public int economy;
    public int politic;
    public static JudgeStats instance;

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(trust < 0 ) trust = 0;
        if(conscience < 0 ) conscience = 0;
        if(economy < 0 ) economy = 0;
        if(politic < 0 ) politic = 0;
    }
}
