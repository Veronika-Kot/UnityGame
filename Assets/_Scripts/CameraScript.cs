using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;    
    public Transform leftPoint;  
    public Transform rightPoint;

    private float screenHalfWidth;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        // Calculating screen size
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        // Screen half width in game world units
        screenHalfWidth = width / 2.0f;

        transform.position = new Vector3(leftPoint.position.x + screenHalfWidth, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // Don't let camera go to the beyond screen edges
        if(Vector3.Distance(transform.position, new Vector3(leftPoint.position.x, transform.position.y, transform.position.z)) < screenHalfWidth) {
           transform.position = new Vector3(leftPoint.position.x + screenHalfWidth, transform.position.y, transform.position.z);
        }
        if(Vector3.Distance(transform.position, new Vector3(rightPoint.position.x, transform.position.y, transform.position.z)) < screenHalfWidth) {
           transform.position = new Vector3(rightPoint.position.x - screenHalfWidth, transform.position.y, transform.position.z);
        }
    }
}
