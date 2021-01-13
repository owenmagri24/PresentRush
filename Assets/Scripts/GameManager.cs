using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int presentCount; //public variable to be accessed by other scripts

    public Text presentText; //Fetching Text object to update numbers of presents on screen

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        presentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        presentText.text = "Presents: "+ presentCount; //Displays and updates present count
    }

    public void CollectedPresent()
    {
        presentCount++;
    }

    public void PresentLimit()
    {
        if (presentCount > 3)
        {
            //lower presentCount from 4 to 3 and keep the limit of presents at 3 at all time
            presentCount--;
            Debug.Log("Present Count: "+ presentCount);
            
        }
        else
        {
            Debug.Log("Present Count: "+ presentCount);
            // Destroys present if player has less than 3presents. This way, the presents don't get destroyed if player has 3 presents already.
            Destroy(GameObject.FindWithTag("Present")); 
        }
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
