using System.Collections;
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
    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.transform.name == "Player")
        {
            
            //run the CollectedPresent(); function from GameManager script
            _gameManager.CollectedPresent();
            _gameManager.PresentLimit();
            //if player picks up present, present is destroyed
            Destroy(this.gameObject);
        }
    }
}
