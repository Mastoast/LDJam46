using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMap : MonoBehaviour
{
    public Image shipMap;

    public Image map_AileGauche;
    public Image map_AileDroite;
    public Image map_Avant;
    public Image map_Centre;
    public Image map_Arriere;

    public Sprite yellow_AileGauche;
    public Sprite yellow_AileDroite;
    public Sprite yellow_Avant;
    public Sprite yellow_Centre;
    public Sprite yellow_Arriere;

    public Sprite orange_AileGauche;
    public Sprite orange_AileDroite;
    public Sprite orange_Avant;
    public Sprite orange_Centre;
    public Sprite orange_Arriere;

    public Sprite red_AileGauche;
    public Sprite red_AileDroite;
    public Sprite red_Avant;
    public Sprite red_Centre;
    public Sprite red_Arriere;

    int dmg_AileGauche = 0;
    int dmg_AileDroite = 0;
    int dmg_Avant = 0;
    int dmg_Centre = 0;
    int dmg_Arriere = 0;

    public void LeftWing()
    {
        if (dmg_AileGauche < 2)
            map_AileGauche.gameObject.SetActive(true);
        else if (dmg_AileGauche < 4)
            map_AileGauche.sprite = orange_AileGauche;
        else 
            map_AileGauche.sprite = red_AileGauche;

        dmg_AileGauche++;
    }

    public void RightWing()
    {
        if (dmg_AileDroite < 2)
            map_AileDroite.gameObject.SetActive(true);
        else if (dmg_AileDroite < 4)
            map_AileDroite.sprite = orange_AileDroite;
        else
            map_AileDroite.sprite = red_AileDroite;

        dmg_AileDroite++;
    }

    public void Front()
    {
        if (dmg_Avant < 2)
            map_Avant.gameObject.SetActive(true);
        else if (dmg_Avant < 4)
            map_Avant.sprite = orange_Avant;
        else
            map_Avant.sprite = red_Avant;

        dmg_Avant++;
    }

    public void Center()
    {
        if (dmg_Centre < 2)
            map_Centre.gameObject.SetActive(true);
        else if (dmg_Centre < 4)
            map_Centre.sprite = orange_Centre;
        else
            map_Centre.sprite = red_Centre;

        dmg_Centre++;
    }

    public void Back()
    {
        if (dmg_Arriere < 2)
            map_Arriere.gameObject.SetActive(true);
        else if (dmg_Arriere < 4)
            map_Arriere.sprite = orange_Arriere;
        else
            map_Arriere.sprite = red_Arriere;

        dmg_Arriere++;
    }
}
