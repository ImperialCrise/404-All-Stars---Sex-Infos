using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    public static MenuSystem Instance;
    
    public Transform AnswersParent;
    public GameObject AnswersPrefab;

    public GameObject Menu;
    public GameObject TitleSpawner;
    private List<AnswerItem> answerList;
    public bool isOpen = false;
    
    private void Start()
    {
        Instance = this;
        answerList = new List<AnswerItem>();
        CloseMenu();
    }

    public void CloseMenu()
    {
        LeanTween.scale(Menu, Vector3.zero, 0.5f).setEaseOutBounce().setOnComplete(() =>
        {
            isOpen = false;
            Menu.SetActive(false);
        });
    }
    
    public void showQuestion(Question question)
    {
        if (isOpen)
            return;
        
        answerList.Clear();
        foreach (Transform child in AnswersParent)
            Destroy(child.gameObject);
        foreach (Transform child in TitleSpawner.transform)
            Destroy(child.gameObject);

        Instantiate(question.Title, TitleSpawner.transform);
        
        foreach (var answer in question.Answers)
        {
            var answeritem = Instantiate(AnswersPrefab, AnswersParent).GetComponent<AnswerItem>();
            answeritem.SetInfos(answer);
            answerList.Add(answeritem);
        }

        Menu.SetActive(true);
        LeanTween.scale(Menu, Vector3.one, 0.5f).setEaseInBounce();
        
        isOpen = true;
    }

    public void onClickOnAnswer()
    {
        foreach (var answerItem in answerList)
        {
            answerItem.ShowAnswer();   
        }
    }

}

