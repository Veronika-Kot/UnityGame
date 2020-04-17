/**
* Author: Veronika Kotckovich
* Student ID: 301067511
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for Help screen buttons
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