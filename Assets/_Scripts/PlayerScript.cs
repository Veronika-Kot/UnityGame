using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Vector3 defaulPosition;
    private Vector2 offset;
    private Vector2 mouseDownPos;
    private Vector2 oldCameraPosition;

    [Header("Canvas")]
    public Camera camera;
    public Text scoreLabel;
    private int score;

    
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

        offset = Vector2.zero;

        touchedGround = false;

        defaulPosition = transform.position;
        score = 0;
    }

     private IEnumerator wait(float sec) {
        yield return new WaitForSeconds(sec);
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            mouseDownPos = camera.ScreenToWorldPoint (Input.mousePosition);
            oldCameraPosition = camera.transform.position;
        } 

        if (Input.GetMouseButton(0))
        {
            animController.SetInteger("AnimState", 1);

            Vector2 mouseDragPos = camera.ScreenToWorldPoint (Input.mousePosition);
            mouseDragPos += offset;

            Vector2 temtMouseDownPos = mouseDownPos + offset;
            Vector2 direction =  mouseDragPos - temtMouseDownPos;
            direction.Normalize();

            //Debug.Log(mouseDownPos + "  " + mouseDragPos + " " + direction);
            offset += speed * direction * 0.01f;

            rb.velocity = new Vector2(speed * direction.x, rb.velocity.y);

            if (direction.y > 0.3 && touchedGround) {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                touchedGround = false;
            }
        
            if(Mathf.Abs(rb.velocity.x ) > maxVelocity) {
                float newXVelocity = direction.x * maxVelocity;
                rb.velocity = new Vector2(newXVelocity, rb.velocity.y);
            }

        } else {
            animController.SetInteger("AnimState", 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
            offset = Vector2.zero;
        }

        camera.transform.position = new Vector3(rb.position.x, camera.transform.position.y, camera.transform.position.z);

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.gameObject.tag == "Ground")
        {
            touchedGround = true;
        }
        if(col.collider.gameObject.tag == "Cherry")
        {
            Destroy(col.collider.gameObject);
            score ++;
            scoreLabel.text = "Score: " + score.ToString();
        }
        if(col.collider.gameObject.tag == "Obsticle")
        {
            transform.position = defaulPosition;
        }
    }


}
