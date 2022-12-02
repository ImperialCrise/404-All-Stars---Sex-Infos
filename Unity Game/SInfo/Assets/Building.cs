using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    public CanvasGroup CanvasGroup;

    [Header("Answers:")] 
    public GameObject[] Questions;

    private int index = 0;
    private int length = 0;
    public bool isClickable = false;
    
    void Start()
    {
        CanvasGroup.alpha = 0f;
        length = Questions.Length;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isClickable = true;
            LeanTween.value(gameObject, f => CanvasGroup.alpha = f, 0f, 1f, 0.5f);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isClickable = false;
            LeanTween.value(gameObject, f => CanvasGroup.alpha = f, 1f, 0f, 0.5f);
        }
    }

    public void onClickOnButton()
    {
        if (isClickable)
        {
            MenuSystem.Instance.showQuestion(Questions[Random.Range(0, length)]);
        }
    }
}
