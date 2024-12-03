using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackToGameplay : MonoBehaviour
{
    private bool canRestart = false;
    public GameObject retryTMP;

    private void Start()
    {
        StartCoroutine(delaySeconds());
    }

    // Update is called once per frame
    void Update()
    {
        if (canRestart)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Gameplay");
            }
        }
    }

    IEnumerator delaySeconds()
    {
        yield return new WaitForSeconds(5f);
        retryTMP.SetActive(true);
        canRestart = true;
    }
}
