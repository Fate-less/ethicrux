using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseStats : MonoBehaviour
{
    public int agreeTrust { get; private set; }
    public int agreeConscience { get; private set; }
    public int agreeEconomy { get; private set; }
    public int agreePolitic { get; private set; }
    public int declineTrust { get; private set; }
    public int declineConscience { get; private set; }
    public int declineEconomy { get; private set; }
    public int declinePolitic { get; private set; }
    public string testCase { get; private set; }

    public void Apply(ScriptableObject data)
    {
        if(data is CaseSO caseSO)
        {
            agreeTrust = caseSO.agreeTrust;
            agreeConscience = caseSO.agreeConscience;
            agreeEconomy = caseSO.agreeEconomy;
            agreePolitic = caseSO.agreePolitic;
            declineTrust = caseSO.declineTrust;
            declineConscience = caseSO.declineConscience;
            declineEconomy = caseSO.declineEconomy;
            declinePolitic = caseSO.declinePolitic;
        }
    }
}
