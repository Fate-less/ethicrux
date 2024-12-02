using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class StatModifier : MonoBehaviour
{
    public static StatModifier instance;

    public TMP_Text ConscienceTmp;
    public TMP_Text EconomyTmp;
    public TMP_Text PoliticsTmp;
    public TMP_Text TrustTmp;

    public Animator ConscienceAnim;
    public Animator EconomyAnim;
    public Animator PoliticsAnim;
    public Animator TrustAnim;

    public Slider trustslider;
    public Slider conscienceslider;
    public Slider economyslider;
    public Slider politicslider;

    void Awake()
    {
        instance = this;

    }
    void Start()
    {

        trustslider.maxValue = JudgeStats.instance.trust * 2;
        conscienceslider.maxValue = JudgeStats.instance.conscience * 2;
        economyslider.maxValue = JudgeStats.instance.economy * 2;
        politicslider.maxValue = JudgeStats.instance.politic * 2;

        trustslider.value = JudgeStats.instance.trust;
        conscienceslider.value = JudgeStats.instance.conscience;
        economyslider.value = JudgeStats.instance.economy;
        politicslider.value = JudgeStats.instance.politic;
    }

    public void ChangeStatCheck( int Trust, int Conscience, int Economy, int Politics)
    {
        if(Conscience > 0)
        {
            ConscienceTmp.text = "+" + Conscience.ToString();
            ConscienceAnim.SetTrigger("Plus");
        }
        else if(Conscience < 0 )
        {
            ConscienceTmp.text = Conscience.ToString();
            ConscienceAnim.SetTrigger("Minus");
        }
        else
        {
            ConscienceAnim.SetTrigger("Default");
        }

        if(Economy > 0)
        {
            EconomyTmp.text = "+" + Economy.ToString();
            EconomyAnim.SetTrigger("Plus");
        }
        else if(Economy < 0 )
        {
            EconomyTmp.text = Economy.ToString();
            EconomyAnim.SetTrigger("Minus");
        }
        else
        {
            EconomyAnim.SetTrigger("Default");
        }


        if(Politics > 0)
        {
            PoliticsTmp.text = "+" + Politics.ToString();
            PoliticsAnim.SetTrigger("Plus");
        }
        else if(Politics < 0 )
        {
            PoliticsTmp.text = Politics.ToString();
            PoliticsAnim.SetTrigger("Minus");
        }
        else
        {
            PoliticsAnim.SetTrigger("Default");
        }

        if(Trust > 0)
        {
            TrustTmp.text = "+" + Trust.ToString();
            TrustAnim.SetTrigger("Plus");
        }
        else if(Trust < 0 )
        {
            TrustTmp.text = Trust.ToString();
            TrustAnim.SetTrigger("Minus");
        }
        else
        {
            TrustAnim.SetTrigger("Default");
        }
    }

    
    public Animator anim;
    public void ChangeStat( int trust, int conscience, int economy, int politics)
    {
        anim.SetTrigger("Flash");
        AudioManager.instance.PlaySFX("Flash");
        DOTween.To(() => trustslider.value, x => trustslider.value = x, JudgeStats.instance.trust + trust, 0.5f);
        DOTween.To(() => conscienceslider.value, x => conscienceslider.value = x, JudgeStats.instance.conscience + conscience, 0.5f);
        DOTween.To(() => economyslider.value, x => economyslider.value = x, JudgeStats.instance.economy + economy, 0.5f);
        DOTween.To(() => politicslider.value, x => politicslider.value = x,  JudgeStats.instance.politic + politics, 0.5f);

        JudgeStats.instance.trust += trust;
        JudgeStats.instance.conscience += conscience;
        JudgeStats.instance.economy += economy;
        JudgeStats.instance.politic += politics;
    }
}
