using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> tutorials = new List<Tutorial>();
    public Text text;
    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<TutorialManager>();
                if(instance == null)
                {
                    Debug.Log("no tutorial manager");
                }
            }
            return instance;
        }
    }
    private Tutorial currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        setNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
        {
            currentTutorial.checkIfHappening();
        }
    }

    public void completedTutorial()
    {
        setNextTutorial(currentTutorial.order + 1);
    }

    public void setNextTutorial(int currentOrder)
    {
        currentTutorial = getTutorialByOrder(currentOrder);
        if (!currentTutorial)
        {
            text.text = "finished";
        }
        else
        {
            Debug.Log(currentTutorial.explanation);
            text.text = currentTutorial.explanation;
        }
    }


    public Tutorial getTutorialByOrder(int order)
    {
        foreach(Tutorial t in tutorials)
        {
            if(t.order == order)
            {
                return t;
            }
        }
        return null;
    }
}
