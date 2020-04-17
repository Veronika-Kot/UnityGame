/**
* Author: Veronika Kotckovich
* Student ID: 301067511
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class containes even handlers for Buttons click
public class ButtonsScript : MonoBehaviour
{
   public void OnBackButtonPressed() {
       SceneManager.LoadScene("StartScene");
   }

   public void OnStartButtonPressed() {
       SceneManager.LoadScene("DayScene");
   }
    public void OnHelpButtonPressed() {
       SceneManager.LoadScene("HelpScene");
   }
}
