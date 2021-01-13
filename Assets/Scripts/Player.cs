using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //protecting value from changes done by players
    //only designers will be able to change the value
    [SerializeField]
    //setting player movement speed

    public float speed = 6.5f;
    private GameManager _gameManager;

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
        //moving character with WASD / Arrow keys horizontally and vertically
        //will try and make it 4 directional movement only if there is enough time
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal,vertical,0);
        transform.Translate(direction * speed * Time.deltaTime);

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

        /*player movement deduction*/
    }
}
