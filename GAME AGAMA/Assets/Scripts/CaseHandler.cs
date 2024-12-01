using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseHandler : MonoBehaviour
{
    public GameObject CardPrefab;
    public List<CaseSO> CrimeCases;
    public Transform resetPos;

    private void Start()
    {
        SpawnCase();
    }

    public void SpawnCase()
    {
        Debug.Log("Case Spawned");
        if(CrimeCases.Count > 0)
        {
            GameObject newCase = Instantiate(CardPrefab, resetPos.position, resetPos.rotation);
            newCase.GetComponent<CaseStats>().Apply(CrimeCases[0]);
            CrimeCases.RemoveAt(0);
        }
        else
        {
            //true ending
        }
    }
}
