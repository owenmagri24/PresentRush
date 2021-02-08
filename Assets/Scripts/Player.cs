using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //protecting value from changes done by players
    //only designers will be able to change the value
    public Animator animator; //variable used to call animator

    [SerializeField]
    //setting player movement speed
    public float speed = 6.5f;
    private GameManager _gameManager;

    private bool facingRight = true; //variable used for direction facing

    // Start is called before the first frame update
    void Start()
    {
        //set player position to (X 0)(Y 0)(Y 0)
        transform.position = new Vector3(0,0,0);

        //finding the GameManager object and then the script itself
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //preventing crashes, if GameManager isn't found a message will be included in the console
        if(_gameManager == null)
        {
            Debug.Log("GameManager was not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        _gameManager.PlayerSpeed();
    }

    void playerMovement()
    {
        //moving character with WASD buttons and 4 directional movement

        //if the character is not facing the right side, flip it's animation for it to be able to face the right side
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            if (!facingRight)
            {
                flip();
            }
        }

        //if the character is not facing the left side, flip it's animatino for it to be able to face the left side
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            if (facingRight)
            {
                flip();
            }
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }

        //player boundaries / walls

        //if player position is over the value of 8.3f on the X axis, the player will not be able to move into that direction any further
        if(transform.position.x > 8.3f)
        {
            transform.position = new Vector3 (8.3f,transform.position.y,0);
        }

        //if player position is under the value of -8.3f on the X axis, the player will not be able to move into that direction any further
        if(transform.position.x < -8.3f)
        {
            transform.position = new Vector3 (-8.3f,transform.position.y,0);
        }

        //if player position is over the value of 4.4f on the Y axis, the player will not be able to move into that direction any further
        if(transform.position.y > 4.4f)
        {
            transform.position = new Vector3 (transform.position.x,4.4f,0);
        }

        //if player position is over the value of -4.4f on the Y axis, the player will not be able to move into that direction any further
        if(transform.position.y < -4.4f)
        {
            transform.position = new Vector3 (transform.position.x,-4.4f,0);
        }

    }

    //Function to flip scale
    void flip(){
        //changes facingRight to false, gets localscale and multipies x value by -1 and applies it to localScale again.
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
