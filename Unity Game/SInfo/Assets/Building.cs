using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    public CanvasGroup CanvasGroup;

    [Header("Image Prefab Question:")] 
    public GameObject Title;
    
    [Header("Answers:")] 
    public Question[] Questions;

    private int index = 0;
    private int length = 0;

    
    void Start()
    {
        CanvasGroup.alpha = 0f;
        length = Questions.Length;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        LeanTween.value(gameObject, f => CanvasGroup.alpha = f, 0f, 1f, 0.5f);
    }

    public void OnTriggerExit2D(Collider other)
    {
        LeanTween.value(gameObject, f => CanvasGroup.alpha = f, 1f, 0f, 0.5f);
    }

    public void onClickOnButton()
    {
        MenuSystem.Instance.showQuestion(Questions[Random.Range(0, length)]);
        //index = (index + 1) % length;
    }
}
