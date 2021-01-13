using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Children : MonoBehaviour
{
    //Despawn timer variable. SerializeField given to be changed by designers
    [SerializeField]
    private float despawn = 3f;

    private GameManager _gameManager;
    void Start()
    {
        //finding the GameManager object and then the script itself
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //preventing crashes, if GameManager isn't found a message will be included in the console
        if(_gameManager == null)
        {
            Debug.Log("GameManager was not found");
        }

        //destroys game object after set amount of seconds
        Destroy(this.gameObject, despawn); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        //If Child collides with player AND player has presents, child is destroyed and present count is deducted by 1
        if(other.transform.name == "Player" && _gameManager.presentCount > 0)
        {
            Destroy(this.gameObject); //destroys child
            _gameManager.presentCount--; //deducts presentcount by 1
            Debug.Log("Present Count: "+ _gameManager.presentCount);
        }
    }
}
