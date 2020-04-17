using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsScript : MonoBehaviour
{
    public GameObject gameKeeper;
   
    //Checking colliosion with player
     void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameKeeper.GetComponent<GameUpdateScript>().addLife();
        }
    }
}
