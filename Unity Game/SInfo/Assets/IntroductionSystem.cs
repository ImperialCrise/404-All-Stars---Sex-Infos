using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroductionSystem : MonoBehaviour
{
    public static IntroductionSystem Instance;
    public int history = -1;
    
    public bool CanContinue;
    public GameObject MessageBubble;
    public TextMeshProUGUI MessageBubbleText;
    public GameObject Worker;
    public GameObject MouseImage;
    
    
    void Start()
    {
        //MessageBubble.gameObject.transform.localScale = Vector3.zero;

        Instance = this;
        MouseImage.SetActive(false);
        NextMessage();
    }

    void Update()
    {
        if (!CanContinue)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            CanContinue = false;
            NextMessage();
        }
    }
    
    void NewMessage(string text, bool conte)
    {
        LeanTween.scale(Worker.gameObject, new Vector3(31f, 31f, 31f), 0.1f).setOnComplete(() =>
        {
            LeanTween.scale(Worker.gameObject, new Vector3(30f, 30f, 30f), 0.1f).setOnComplete(() => CanContinue = conte);
        });
        
        MessageBubbleText.text = text;
    }

    public bool isFinished => history >= 3;
    public void NextMessage()
    {
        switch (history)
        {
            case -1:
                NewMessage("Bienvenue ! Nous vous attendions !", true);
                break;
            case 0:
                NewMessage("Cette ville abrite de nombreuses maisons.", true);
                break;
            case 1:
                NewMessage("Allez la visiter en utilisant la souris.", true);
                MouseImage.SetActive(true);
                break;
            case 2: //2
                LeanTween.moveX(MouseImage, 3000, 0.5f);
                LeanTween.moveX(Worker, -3000, 0.5f)
                    .setOnComplete(() =>
                    {
                        Worker.SetActive(false);
                        Destroy(gameObject);
                    });
                break;
        }

        history++;
    }
    
}
