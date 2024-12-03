using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if(trust <= 0 ) SceneManager.LoadScene("OutOfTrust");
        if(conscience <= 0 ) SceneManager.LoadScene("OutOfConscience");
        if (economy <= 0 ) SceneManager.LoadScene("OutOfEconomy");
        if (politic <= 0 ) SceneManager.LoadScene("OutOfPolitic");
    }
}
