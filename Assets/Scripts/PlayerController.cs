using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Public Variables
    public float speed = 10.0f;
    public float jumpHeight = 10.0f;

    float vert = 0.00f;
   
    //public Animator animator;

    // Private Variables
    private Rigidbody2D rBody;
    private bool jump = false;
    private bool isRight = false;
 
     
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

  
  
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        int input = 0;

        if(jump == true && Input.GetKeyDown("space"))
        {

            rBody.AddForce(new Vector2(0,jumpHeight));
            //vert = this.transform.position.y + jumpHeight;
            input++;
        }

        if(input >= 2)
        {
            jump = false;
        }


        // Debug.Log("H: " + horiz + " , V: " + vert);
        Vector2 newVelocity = new Vector2(horiz, vert );

        rBody.velocity = newVelocity * speed;

        //animator.SetFloat("direction x", newVelocity.x);
        //animator.SetFloat("direction y", newVelocity.y);

        if(rBody.velocity.x < 0 && isRight)
        {
            Flip();
        }
        else if(rBody.velocity.x > 0 && !isRight)
        {
            Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            jump = true;
        }
    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
