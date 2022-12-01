using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnswerItem : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Answer Answer;
    public Image Background;

    private bool isClicked = false;
    
    void Start()
    {
        
    }

    public void onClick()
    {
        isClicked = true;
        MenuSystem.Instance.onClickOnAnswer();
    }

    public void SetInfos(Answer answer)
    {
        Answer = answer;
        text.text = answer.answerText;
    }

    public void ShowAnswer()
    {
        if (Answer.isRight)
        {
            Background.color = Color.green;
            if (isClicked)
            {
                text.text += "\n bien joué frere";
            }
        }
        else
        {
            Background.color = Color.red;
            if (isClicked)
            {
                text.text += "\n frere t nul";
            }
        }
    }
}
