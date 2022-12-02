using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AnswerItem : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Answer Answer;
    public Image Background;

    private bool isClicked = false;
    public bool isShowed = false;

    public void onClick()
    {
        if (isShowed || isClicked)
            return;
        
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
        isShowed = true;
        if (Answer.isRight)
        {
            Background.color = new Color(0.15f, 0.87f, 0.59f);
            if (isClicked)
            {
                int rand = Random.Range(2, 10);
                MenuSystem.Instance.Change(rand);
                text.text += "\n <color=yellow>Gagné ! +"+rand+"</color>";
            }
        }
        else
        {
            Background.color = new Color(1f, 0.41f, 0.33f);
            int rand = Random.Range(-4, -1);
            MenuSystem.Instance.Change(rand);
            
            if (isClicked)
            {
                text.text += "\n <color=yellow>Perdu ! "+rand+"</color>";
            }
        }
    }
}
