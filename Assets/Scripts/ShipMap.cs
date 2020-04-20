using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMap : MonoBehaviour
{
    public GameObject gameOverWindow;

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

    public Sprite black_AileGauche;
    public Sprite black_AileDroite;
    public Sprite black_Avant;
    public Sprite black_Centre;
    public Sprite black_Arriere;

    int dmg_AileGauche = 0;
    int dmg_AileDroite = 0;
    int dmg_Avant = 0;
    int dmg_Centre = 0;
    int dmg_Arriere = 0;

    public void LeftWing(int dmg)
    {
        dmg_AileGauche += dmg;


        if (dmg_AileGauche < 0)
        {
            dmg_AileGauche = 0;
        }

        if (dmg_AileGauche == 0)
        {
            map_AileGauche.gameObject.SetActive(false);
        }
        else
        {
            map_AileGauche.gameObject.SetActive(true);
            if (dmg_AileGauche < 3)
                map_AileGauche.sprite = yellow_AileGauche;
            else if (dmg_AileGauche < 5)
                map_AileGauche.sprite = orange_AileGauche;
            else
                map_AileGauche.sprite = red_AileGauche;
        }

        if (dmg_AileGauche == 8)
        {
            // Left wing is fully broken => GAME OVER
            map_AileGauche.sprite = black_AileGauche;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "The left wing hasn't been repaired and broke.\nGame Over.";

        }
    }

    public float GetLeftWing()
    {
        if (map_AileGauche.sprite == red_AileGauche)
            return 0.33f;

        if (map_AileGauche.sprite == orange_AileGauche)
            return 0.66f;

        return 1f;
    }

    public void RightWing(int dmg)
    {
        dmg_AileDroite += dmg;


        if (dmg_AileDroite < 0)
        {
            dmg_AileDroite = 0;
        }

        if (dmg_AileDroite == 0)
        {
            map_AileDroite.gameObject.SetActive(false);
        }
        else
        {
            map_AileDroite.gameObject.SetActive(true);
            if (dmg_AileDroite < 3)
                map_AileDroite.sprite = yellow_AileDroite;
            else if (dmg_AileDroite < 5)
                map_AileDroite.sprite = orange_AileDroite;
            else
                map_AileDroite.sprite = red_AileDroite;
        }

        if (dmg_AileDroite == 8)
        {
            // Right wing is fully broken => GAME OVER
            map_AileDroite.sprite = black_AileDroite;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "The right wing hasn't been repaired and broke.\nGame Over.";

        }
    }

    public float GetRightWing()
    {
        if (map_AileDroite.sprite == red_AileDroite)
            return 0.33f;

        if (map_AileDroite.sprite == orange_AileDroite)
            return 0.66f;

        return 1f;
    }

    public void Front(int dmg)
    {
        dmg_Avant += dmg;

        map_Avant.gameObject.SetActive(true);

        if (dmg_Avant < 0)
        {
            dmg_Avant = 0;
        }

        if (dmg_Avant == 0)
        {
            map_Avant.gameObject.SetActive(false);
        }
        else
        {
            map_Avant.gameObject.SetActive(true);
            if (dmg_Avant < 3)
                map_Avant.sprite = yellow_Avant;
            else if (dmg_Avant < 5)
                map_Avant.sprite = orange_Avant;
            else
                map_Avant.sprite = red_Avant;
        }

        if (dmg_Avant == 8)
        {
            // Front is fully broken => GAME OVER
            map_Avant.sprite = black_Avant;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "The front hasn't been repaired and broke.\nGame Over.";

        }
    }

    public float GetFront()
    {
        if (map_Avant.sprite == red_Avant)
            return 0.33f;

        if (map_Avant.sprite == orange_Avant)
            return 0.66f;

        return 1f;
    }

    public void Center(int dmg)
    {
        dmg_Centre += dmg;


        if (dmg_Centre < 0)
        {
            dmg_Centre = 0;
        }

        if (dmg_Centre == 0)
        {
            map_Centre.gameObject.SetActive(false);
        }
        else
        {
            map_Centre.gameObject.SetActive(true);
            if (dmg_Centre < 3)
                map_Centre.sprite = yellow_Centre;
            else if (dmg_Centre < 5)
                map_Centre.sprite = orange_Centre;
            else
                map_Centre.sprite = red_Centre;
        }

        if (dmg_Centre == 8)
        {
            // Center is fully broken => GAME OVER
            map_Centre.sprite = black_Centre;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "The center hasn't been repaired and broke.\nGame Over.";
        }
    }

    public float GetCenter()
    {
        if (map_Centre.sprite == red_Centre)
            return 0.33f;

        if (map_Centre.sprite == orange_Centre)
            return 0.66f;

        return 1f;
    }

    public void Back(int dmg)
    {
        dmg_Arriere += dmg;


        if(dmg_Arriere < 0)
        {
            dmg_Arriere = 0;
        }

        if (dmg_Arriere == 0)
        {
            map_Arriere.gameObject.SetActive(false);
        }
        else
        {
            map_Arriere.gameObject.SetActive(true);
            if (dmg_Arriere < 3)
                map_Arriere.sprite = yellow_Arriere;
            else if (dmg_Arriere < 5)
                map_Arriere.sprite = orange_Arriere;
            else
                map_Arriere.sprite = red_Arriere;
        }

        if (dmg_Arriere == 8)
        {
            // Back is fully broken => GAME OVER
            map_Arriere.sprite = black_Arriere;
            gameOverWindow.SetActive(true);
            gameOverWindow.GetComponentInChildren<Text>().text = "The back hasn't been repaired and broke.\nGame Over.";
        }
    }

    public float GetBack()
    {
        if (map_Arriere.sprite == red_Arriere)
            return 0.33f;

        if (map_Arriere.sprite == orange_Arriere)
            return 0.66f;

        return 1f;
    }

}
