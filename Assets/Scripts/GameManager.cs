using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int presentCount; //public variable to be accessed by other scripts

    public int score; //score variable

    [SerializeField]
    private Sprite[] _presentSprites; //array used to store different present sprites

    [SerializeField]
    private Image _presentImg; //image variable to store default present image

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
        scoreText.text = "Score: "+ score; //Displays and updates score
        UpdatePresentCount();
    }

    public void CollectedPresent()
    {
        presentCount++;
    }

    public void UpdatePresentCount() //function to replace presentimage sprite depending on presentcount value
    {
        _presentImg.sprite = _presentSprites[presentCount];
    }
    public void PlayerSpeed()
    {
        if (presentCount <= 1)
        {
            //do nothing
        }

        else if (presentCount == 2)
        {
            _player.speed = 6f;
        }

        else
        {
            _player.speed = 5f;
        }
    }
}
