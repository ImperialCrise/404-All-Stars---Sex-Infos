using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MenuSystem : MonoBehaviour
{
    public static MenuSystem Instance;
    
    public Transform AnswersParent;
    public GameObject AnswersPrefab;

    public GameObject MenuHelp;
    public GameObject Menu;
    public GameObject TitleSpawner;
    private List<AnswerItem> answerList;
    public bool isOpen = false;

    public bool isHelpOk = false;

    public Slider sliderTime;
    public TextMeshProUGUI TimeTexte;
    public float time = 0;

    public int Bonbons = 0;
    public TextMeshProUGUI BonbonsText;

    public bool isDefinedOpen = false;
    public RectTransform Backgroundfinal;
    
    private void Start()
    {
        Instance = this;
        answerList = new List<AnswerItem>();
        CloseMenu();
        sliderTime.maxValue = 30f;
    }

    public void Update()
    {
        if (isShown || !isOpen)
            return;
        
        time -= Time.deltaTime;
        if (time <= 0)
        {
            sliderTime.value = 0;
            TimeTexte.text = "Temps Écoulé !";
            onClickOnAnswer();
            Change(Random.Range(-4, -1));
        }
        else{
            sliderTime.value = time;
            TimeTexte.text = $"{(int) time} secondes";
        }
    }

    public void Change(int amount)
    {
        Bonbons += amount;
        BonbonsText.text = Bonbons + "";
    }

    public void CloseMenu()
    {
        LeanTween.scale(Menu, Vector3.zero, 0.5f).setEaseOutBounce().setOnComplete(() =>
        {
            isOpen = false;
            isDefinedOpen = false;
            Menu.SetActive(false);
        });
    }
    
    public void showQuestion(GameObject question)
    {
        isDefinedOpen = true;
        if (isOpen)
            return;

        answerList.Clear();
        foreach (Transform child in AnswersParent)
            Destroy(child.gameObject);
        foreach (Transform child in TitleSpawner.transform)
            Destroy(child.gameObject);

        var quest = Instantiate(question, TitleSpawner.transform).GetComponent<Question>();

        var size = Math.Max(quest.GetComponent<RectTransform>().sizeDelta.x + 100, 1026);
        Backgroundfinal.sizeDelta = new Vector2(size, Backgroundfinal.sizeDelta.y);
        
        foreach (var answer in quest.GetComponents<Answer>())
        {
            var answeritem = Instantiate(AnswersPrefab, AnswersParent).GetComponent<AnswerItem>();
            answeritem.SetInfos(answer);
            answerList.Add(answeritem);
        }

        isShown = false;
        
        
        if (!isHelpOk)
        {
            MenuHelp.SetActive(true);
            MenuHelp.transform.localScale = Vector3.zero;
            LeanTween.scale(MenuHelp, Vector3.one, 0.5f).setEaseInBounce();
            return;
        }
        
        isOpen = true;
        Menu.SetActive(true);
        LeanTween.scale(Menu, Vector3.one, 0.5f).setEaseInBounce();
        time = 30.5f;
    }

    public void ClickOnOkHelp()
    {
        isHelpOk = true;
        LeanTween.scale(MenuHelp, Vector3.zero, 0.5f).setEaseInBounce().setOnComplete(() =>
        {
            Menu.SetActive(true);
            LeanTween.scale(Menu, Vector3.one, 0.5f).setEaseInBounce();
            time = 30.5f;
            isOpen = true;
        });
    }

    public bool isShown = false;
    
    public void onClickOnAnswer()
    {
        isShown = true;
        foreach (var answerItem in answerList)
        {
            answerItem.ShowAnswer();   
        }
    }

}

