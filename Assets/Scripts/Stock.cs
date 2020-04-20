using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour
{
    // Put this script anywhere

    public Text textBonbonne;
    public Text textMetal;

    public int metal = 100;
    public int bonbonne = 100;

    void Start()
    {
        textBonbonne.text = bonbonne.ToString();
        textMetal.text = metal.ToString();
    }

    public void ChangeMetal(int i)
    {
        metal += i;
        textMetal.text = metal.ToString();
    }

    public int GetMetal()
    {
        return metal;
    }

    public void ChangeBonbonne(int i)
    {
        bonbonne += i;
        textBonbonne.text = bonbonne.ToString();
    }

    public int GetBonbonne()
    {
        return bonbonne;
    }
}
