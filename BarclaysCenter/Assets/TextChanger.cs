using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{

    public enum Stages { StageZero, StageOne, StageTwo, StageThree, StageFour}
    public Stages myStage = Stages.StageZero;

    [Header ("My Header")]
    private TMP_Text myText;
    public string defaultText = "defaultText";

    public string textOne;
    public string textTwo;
    public int textNumber = 0;
    [Space]
    int count = 0;


    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myText.text = defaultText;
    }

    void EnumTextChanger()
    {
        switch(myStage)
        {
            case Stages.StageZero:
                myText.text = myStage.ToString();
                myStage = Stages.StageOne;
                break;

            case Stages.StageOne:
                myText.text = myStage.ToString();
                myStage = Stages.StageZero;
                break;

            case Stages.StageTwo:

                break;

            case Stages.StageThree:

                break;

            case Stages.StageFour:

                break;
        }
        
        /*
        if (myStage == Stages.StageOne)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageTwo;
        }
        else if(myStage == Stages.StageTwo)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageThree;
        }
        else if (myStage == Stages.StageThree)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageOne;
        }
        */
    }

    void TextInputChanger()
    {
        if(textNumber == 0)
        {
            myText.text = textOne;
            textNumber = 1;
        }
        else if(textNumber == 1)
        {
            myText.text = textTwo;
            textNumber = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            //TextInputChanger();
            EnumTextChanger();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myText.text = "Count: "+ count;
            count += 1;
        }
    }
}
