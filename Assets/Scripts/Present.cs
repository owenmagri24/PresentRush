using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField]
    //setting the amount of time presents need to despawn
    private float despawn = 5f;

    private GameManager _gameManager;

    public AudioSource presentSound;

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

        //finding the Present_sound object and then its AudioSource file
        presentSound = GameObject.Find("Present_sound").GetComponent<AudioSource>();

        //preventing crashes
        if (presentSound == null)
        {
            Debug.Log("Present sound not found");
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
            //else, play the sound of present being picked up, add to present count and destroy present
            presentSound.Play();
            _gameManager.CollectedPresent();
            Destroy(this.gameObject);
        }
    }
}
