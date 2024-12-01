using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crime Case")]
public class CaseSO :ScriptableObject
{
    [Header("Hukum")]
    public int agreeTrust;
    public int agreeConscience;
    public int agreeEconomy;
    public int agreePolitic;
    [Header("Tidak dihukum")]
    public int declineTrust;
    public int declineConscience;
    public int declineEconomy;
    public int declinePolitic;
    [Header("Crime Case")]
    [TextArea] public string testCase;
}
