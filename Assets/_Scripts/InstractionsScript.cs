using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstractionsScript : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    // Start is called before the first frame update

    int activeSlide = 0;
    private void Start() {
        Debug.Log(sprites.Length + " Length");
        image.sprite = sprites[0];
    }

    public void showNextSlide(){
        if (activeSlide < sprites.Length -1){
            activeSlide++;
            image.sprite = sprites[activeSlide];
        }
    }

    public void showPrevSlide(){
        if (activeSlide > 0){
            activeSlide--;
            image.sprite = sprites[activeSlide];
        }
    }
}
