using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUpdateScript : MonoBehaviour
{
    public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }      
      void Awake()
      {
           Score = 0;
      }
 
     void OnGUI()
     {
         GUI.Label(new Rect(0, 0, 100, 25), "Score: " + Score);
     }
}
