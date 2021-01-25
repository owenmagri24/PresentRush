using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Children : MonoBehaviour
{
    //Despawn timer variable. SerializeField given to be changed by designers
    [SerializeField]
    private float _despawn = 7f;

    //[SerializeField]
    //private Renderer _childObject; //Child prefab variable

    [SerializeField] //AngryChild Sprite Variable
    private Sprite _childSpriteAngry;

    private GameManager _gameManager;
    
    private SpawnManager _spawnManager;
    void Start()
    {
        //finding the SpawnManager object and then the script itself
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //finding the GameManager object and then the script itself
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //preventing crashes, if GameManager isn't found a message will be included in the console
        if(_gameManager == null)
        {
            Debug.Log("GameManager was not found");
        }

        //destroys game object after set amount of seconds
        Destroy(this.gameObject, _despawn); 
    }

    // Update is called once per frame
    void Update()
    {
        ChildGameOver();//calling function
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

    //function to change color of child after certain amount of time to indicate that he is about to despawn
    private void ChildGameOver()
    {
        _despawn -= Time.deltaTime; //reducing _despawn variable per second
        if(_despawn < 3f)
        {
            //Gets the SpriteRenderer of this component and changes it to childSpriteAngry Variable
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteAngry;
        }

        if(_despawn < 1f)
        {
            //destroy all game objects tagged Player, Children and Present if a child despawns - this is also game over for the player
            //also direct player to the "GameOver" scene
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(GameObject.FindWithTag("Children"));
            Destroy(GameObject.FindWithTag("Present"));
            _spawnManager.PlayerDies();
            SceneManager.LoadScene("GameOver");
        }
    }
}
