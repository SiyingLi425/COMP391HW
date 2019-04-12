using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody2D rBody;
    private bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        walkLeft();

    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
            walkRight();
        else
            walkLeft();


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DogTurn")
                     Flip();
    }

    private void walkRight()
    {
        rBody.velocity = Vector2.right * speed;
    }
    private void walkLeft()
    {
        rBody.velocity = Vector2.left * speed;
    }

    private void Flip()
    {
        isRight = !isRight;

        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
