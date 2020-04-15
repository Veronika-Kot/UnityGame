﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsScript : MonoBehaviour
{
    public GameObject gameKeeper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameKeeper.GetComponent<GameUpdateScript>().addLife();
        }
    }
}
