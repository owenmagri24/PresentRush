using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    //Despawn timer variable. SerializeField given to be changed by designers
    [SerializeField]
    private float despawn = 3f;
    void Start()
    {
        //destroys game object after set amount of seconds
        Destroy(this.gameObject, despawn); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //function to destroy child on collision with player
    private void OnTriggerEnter(Collider other) {
        //If Child collides with player, child is destroyed
        if(other.transform.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
