using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    // Public Variables
    public float speed = 10.0f;
    public float jumpHeight = 10.0f;
    public Text gameOverText;
    public Text restartText;
    public Text scoreText;
    public Text win;
    public int score;

    float vert = 0.00f;
   
    //public Animator animator;

    // Private Variables
    private Rigidbody2D rBody;
    private bool jump = false;
    private bool isRight = false;
    private bool gameOver = false;
    private bool restart = false;
 
     
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
      

        if (jump && Input.GetKeyDown(KeyCode.Space))
        {

           
            jump = false;
            rBody.AddForce(new Vector2(0.0f, jumpHeight));
            
            

        }


        if (gameOver)
        {
            restartText.gameObject.SetActive(true);
            restartText.text = "Press R for Restart";
            
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
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
       

        if (other.tag == "DogTurn")
        {
            
        }

        if (other.tag == "Death")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //ASK PROFESSOR 
            gameOver = true;
            restart = true;
            //this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
            



        }

        if (other.tag == "Goal")
        {
            win.gameObject.SetActive(true);
        }
    }

   
    void UpdateScore()
    {
        scoreText.text = "Energy: " + score;
    }

    //accepts score values, then calls update score.
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
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
