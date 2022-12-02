using UnityEngine;
using UnityEngine.UI;

public class AnimatorToImage : MonoBehaviour
{
    public float duration;
 
    [SerializeField] private Sprite[] sprites;

    // Update is called once per frame
    private Image image;
    private int index;
    private float timer;
 
    void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if ((timer += Time.deltaTime) < duration) 
            return;
        
        timer = 0;
        image.sprite = sprites[index];
        index = (index + 1) % sprites.Length;
    }
}
