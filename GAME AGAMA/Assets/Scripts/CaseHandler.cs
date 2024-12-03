using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CaseHandler : MonoBehaviour
{
    public GameObject CardPrefab;
    public List<CaseSO> CrimeCases;
    public Transform resetPos;
    public TextMeshPro caseCounterTMP;
    public TextMeshPro agreeCaseArgument;
    public TextMeshPro declineCaseArgument;
    private int caseCounter = 0;

    private void Start()
    {
        SpawnCase();
    }

    public void SpawnCase()
    {
        Debug.Log("Case Spawned");
        caseCounter++;
        caseCounterTMP.text = caseCounter.ToString("D2");
        if (CrimeCases.Count > 0)
        {
            GameObject newCase = Instantiate(CardPrefab, resetPos.position, resetPos.rotation);
            CaseStats newCaseStats = newCase.GetComponent<CaseStats>();
            newCaseStats.Apply(CrimeCases[0]);
            agreeCaseArgument.text = newCaseStats.agreeCaseArgument;
            declineCaseArgument.text = newCaseStats.declineCaseArgument;
            CrimeCases.RemoveAt(0);
        }
        else
        {
            SceneManager.LoadScene("TrueEnding");
        }
    }
}
