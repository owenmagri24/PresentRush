using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int presentCount; //public variable to be accessed by other scripts

    public int score; //score variable

    public Text presentText; //Fetching persent text object to update numbers of presents on screen

    public Text scoreText; //Fetcing score text object to update text

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        presentCount = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        presentText.text = "Presents: "+ presentCount; //Displays and updates present count
        scoreText.text = "Score: "+ score; //Displays and updates score
    }

    public void CollectedPresent()
    {
        presentCount++;
    }
    public void PlayerSpeed()
    {
        if (presentCount <= 1)
        {
            //do nothing
        }

        else if (presentCount == 2)
        {
            _player.speed = 5.5f;
        }

        else
        {
            _player.speed = 5f;
        }
    }
}
