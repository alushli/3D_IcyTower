using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce, jumpForce = 45000f, moveDownForce = 2000;
    private bool isOnGround = false;
    public bool isGameEnd = false, isGamePause = false;
    public int score = 0;
    private float playerMaxHeight, stepSize = 1f;
    
    // Start is called before the first frame update
    void start()
    {
        playerMaxHeight = transform.position.y;
    }

    // Update is called once per frame
    // the function change player move speed according to the place of the player
    // also, listen to the user's inputs and move the player
    void Update()
    {
        if (!isOnGround)
        {
            moveForce = 1000f;
        }
        else
        {
            moveForce = 1500f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && CanMove())
        {
           
            transform.GetComponent<Rigidbody>().AddForce(-moveForce * transform.right);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && CanMove())
        {
            transform.GetComponent<Rigidbody>().AddForce(moveForce * transform.right);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && CanMove())
        {
            transform.GetComponent<Rigidbody>().AddForce(-moveDownForce * transform.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && CanMove())
        {
            transform.GetComponent<Rigidbody>().AddForce(jumpForce * transform.up);
            isOnGround = false;
        }
    }

    // the player can jump if he on ground or step
    // the score update coording to the step he pass
    // the player lose when he touch the destructor element
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "canJump")
        {
            isOnGround = true;
            if(collision.transform.position.y > playerMaxHeight && transform.position.y >= collision.transform.position.y + stepSize)
            {
                if(collision.transform.name != "Ground")
                {
                    score += (int)((collision.transform.position.y - playerMaxHeight) / 10);
                }
                playerMaxHeight = collision.transform.position.y;
            }
        } 
        else if (collision.transform.tag == "destructor")
        {
            isGameEnd = true;
        }
    }

    // the function return true if player can move on the game
    bool CanMove()
    {
        if(!isGamePause && !isGameEnd)
            return true;
        return false;
    }
}
