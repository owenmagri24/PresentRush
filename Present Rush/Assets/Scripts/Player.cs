using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //protecting value from changes done by players
    //only designers will be able to change the value
    [SerializeField]
    //setting player movement speed

    private float _speed = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        //set player position to (X 0)(Y 0)(Y 0)
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();  
    }

    void playerMovement()
    {
        //moving character with WASD / Arrow keys horizontally and vertically
        //will try and make it 4 directional movement only if there is enough time
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal,vertical,0);
        transform.Translate(direction * _speed * Time.deltaTime);

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
}
