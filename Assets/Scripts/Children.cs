using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Children : MonoBehaviour
{
    //Despawn timer variable. SerializeField given to be changed by designers
    [SerializeField]
    private float _despawn;

    [SerializeField] //AngryChild Sprite Variable
    private Sprite _childSpriteAngry;

    [SerializeField]
    private Sprite _childSpriteNeutral;

    [SerializeField]
    private Sprite _childSpriteHappy;

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

        DifficultyDespawn(); //calling difficultydespawn function
        //destroys game object after set amount of seconds
        Destroy(this.gameObject, _despawn);
    }

    // Update is called once per frame
    void Update()
    {
        ChildGameOver();//calling function
        Debug.Log("Despawn: "+_despawn);
    }
    
    private void OnTriggerEnter(Collider other) {
        //If Child collides with player AND player has presents, child is destroyed and present count is deducted by 1
        if(other.transform.name == "Player" && _gameManager.presentCount > 0)
        {
            Destroy(this.gameObject); //destroys child
            _gameManager.presentCount--; //deducts presentcount by 1
            CalculateScore();
        }
    }

    private void DifficultyDespawn() //function to change despawn timer depending on score
    {
        if(_gameManager.score < 30)
        {
            _despawn = 10f;
        }
        else if(_gameManager.score >= 30 && _gameManager.score < 60)
        {
            _despawn = 9f;
        }
        else if(_gameManager.score >= 60 && _gameManager.score < 100)
        {
            _despawn = 8f;
        }
        else if(_gameManager.score >= 100)
        {
            _despawn = 7f;
        }
    }

    //function to change color of child after certain amount of time to indicate that he is about to despawn depending on difficulty.
    private void ChildGameOver()
    {
        _despawn -= Time.deltaTime;

        if(_gameManager.score < 30)
        {
            EasyTemper();
        }
        else if(_gameManager.score >= 30 && _gameManager.score < 60)
        {
            MediumTemper();
        }
        else if(_gameManager.score >= 60 && _gameManager.score < 100)
        {
            HardTemper();
        }
        else if(_gameManager.score >= 100)
        {
            CrazyTemper();
        }
        if(_despawn < 0.2f) //player loses
        {
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(GameObject.FindWithTag("Children"));
            Destroy(GameObject.FindWithTag("Present"));
            _spawnManager.PlayerDies();
            SceneManager.LoadScene("GameOver");
        }
    }

    private void CalculateScore() //function that awards score depending on state of child
    {
        if(this.GetComponent<SpriteRenderer>().sprite == _childSpriteHappy)
        {
            _gameManager.score += 3;
        }
        else if(this.GetComponent<SpriteRenderer>().sprite == _childSpriteNeutral)
        {
            _gameManager.score += 2;
        }
        else if(this.GetComponent<SpriteRenderer>().sprite == _childSpriteAngry)
        {
            _gameManager.score += 1;
        }
    }

    private void EasyTemper()
    {
        if(_despawn < 6f){
            //Gets the SpriteRenderer of this component and changes it to childSpriteNeutral Variable
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteNeutral;
        }
        if(_despawn < 3f)
        {
            //Gets the SpriteRenderer of this component and changes it to childSpriteAngry Variable
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteAngry;
        }
    }

    private void MediumTemper()
    {
        if(_despawn < 5.5f){
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteNeutral;
        }
        if(_despawn < 2.5f)
        {
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteAngry;
        }
    }

    private void HardTemper()
    {
        if(_despawn < 5f){
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteNeutral;
        }
        if(_despawn < 2f)
        {
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteAngry;
        }
    }

    private void CrazyTemper()
    {
        if(_despawn < 4.5f){
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteNeutral;
        }
        if(_despawn < 2f)
        {
            this.GetComponent<SpriteRenderer>().sprite = _childSpriteAngry;
        }
    }
}
