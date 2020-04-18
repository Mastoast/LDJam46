using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour
{
    // Put this script anywhere

    public Text textStock;

    int metal = 100;
    int bonbonne = 100;

    void Start()
    {
        textStock.text = "Metal : 100" + System.Environment.NewLine + "Bonbonne : 100";
    }

    public void ChangeMetal(int i)
    {
        metal += i;
        textStock.text = "Metal : " + metal + System.Environment.NewLine + "Bonbonne : " + bonbonne;
    }

    public int GetMetal()
    {
        return metal;
    }

    public void ChangeBonbonne(int i)
    {
        bonbonne += i;
        textStock.text = "Metal : " + metal + System.Environment.NewLine + "Bonbonne : " + bonbonne;
    }

    public int GetBonbonne()
    {
        return bonbonne;
    }
}
