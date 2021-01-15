﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField]
    //setting the amount of time presents need to despawn
    private float despawn = 5f;

    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        //finding the GameManager object and then the script itself
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //preventing crashes, if GameManager isn't found a message will be included in the console
        if(_gameManager == null)
        {
            Debug.Log("GameManager was not found");
        }
        //start the despawn timer
        Destroy(this.gameObject, despawn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other) 
    {
        
        if(other.transform.name == "Player" &&  _gameManager.presentCount >= 3)
        {
            //If collides with player and present count 3 or higher, do nothing
        }
        else if (other.transform.name == "Player")
        {
            //else, add to preset count and destroy present
            _gameManager.CollectedPresent();
            Destroy(this.gameObject);
        }
    }
}
