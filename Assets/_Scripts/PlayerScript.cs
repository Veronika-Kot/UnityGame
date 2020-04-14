using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Vector3 defaulPosition;
    private Vector2 mouseDownPos;
    private Vector2 oldCameraPosition;

    public Camera camera;
    
    [Header("Physics")]
    public Rigidbody2D rb;
    public float speed;
    public float maxVelocity;
    public bool touchedGround;
    public float jumpSpeed;

    [Header("Animations")]
    public Animator animController;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Created");
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 0.0f;
        rb.freezeRotation = true;

        touchedGround = false;
        defaulPosition = transform.position;
    }

     private IEnumerator wait(float sec) {
        yield return new WaitForSeconds(sec);
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get original position of the tap
        if (Input.GetMouseButtonDown(0)) {
            mouseDownPos = Input.mousePosition;
        } 

        // Get updated position of the tap
        if (Input.GetMouseButton(0))
        {
            // Calculating mouse drag direction
            Vector2 mouseDragPos = Input.mousePosition;
            Vector2 direction =  mouseDragPos - mouseDownPos;
            direction.Normalize();

            //Debug.Log(mouseDownPos + "  " + mouseDragPos + " " + direction);
          

            // Apply force to the player according to drag direction
            if(direction.x > 0) {
                rb.AddForce(new Vector2(speed, 0.0f));
                transform.localScale = new Vector3(8.0f, 8.0f, 8.0f);
                // Setting animation to walk
                animController.SetInteger("AnimState", 1);
                //transform.localScale * new Vector3(1.0f, 1.0f, 1.0f);
            } else if(direction.x < 0) {
                rb.AddForce(new Vector2(-speed, 0.0f));
                transform.localScale = new Vector3(-8.0f, 8.0f, 8.0f);
                // Setting animation to walk
                 animController.SetInteger("AnimState", 1);
            }

            // Keep Velocity in a range
            var xVelocity = Mathf.Clamp(Mathf.Abs(rb.velocity.x), 0.0f, maxVelocity);
            rb.velocity = new Vector2(xVelocity * direction.x, rb.velocity.y);

            // Jump
            if (direction.y > 0.4 && touchedGround) {
                animController.SetInteger("AnimState", 2);
                rb.AddForce(new Vector2(0.0f, jumpSpeed));
                touchedGround = false;
            }

        // Idle
        } else {
            animController.SetInteger("AnimState", 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //camera.transform.position = new Vector3(rb.position.x, camera.transform.position.y, camera.transform.position.z);

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.gameObject.tag == "Ground")
        {
            touchedGround = true;
        }

        if(col.collider.gameObject.tag == "Obsticle")
        {
            transform.position = defaulPosition;
        }
    }
}
