using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstractionButtonsScript : MonoBehaviour
{
    public GameObject instractionsKeeper;

  public void OnNextSlide(){
        
        instractionsKeeper.GetComponent<InstractionsScript>().showNextSlide();
        
    }

    public void OnPrevSlide(){
       instractionsKeeper.GetComponent<InstractionsScript>().showPrevSlide();
    }
}