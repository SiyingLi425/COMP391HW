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
        float vert = 0;
        //float vert = Input.GetAxis("Vertical");
        

        // Vector2 newVelocity = new Vector2(horiz, vert);

        // rBody.velocity = newVelocity * speed;

        if (jump && Input.GetKeyDown(KeyCode.Space))
        {

            //for(int i = 0; i < 10; i+= 10)
            //{
            //    gameObject.transform.Translate(Vector3.up * 200 * Time.deltaTime);
            //    //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200), ForceMode2D.Impulse);
            //}
            jump = false;
            rBody.AddForce(new Vector2(0.0f, jumpHeight));
            
            

        }







        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
       
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

        if (other.tag == "Death")
        {
            Destroy(this.gameObject);
            //Vector2 respawn = new Vector2(0, 0);
            //rBody.velocity = respawn * speed;
            Debug.Log("GAME OVER");

        }

        if (other.tag == "Goal")
        {
            Debug.Log("CONGRATULATIONS");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        jump = true;
    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
