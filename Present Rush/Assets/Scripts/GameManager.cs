using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _presentCount;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _presentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectedPresent()
    {
        _presentCount++;
    }

    public void PresentLimit()
    {
        if (_presentCount > 3)
        {
            _presentCount--;
            Debug.Log("Present Count: "+ _presentCount);
            //lower presentCount from 4 to 3 and keep the limit of presents at 3 at all time
        }
        else
        {
            Debug.Log("Present Count: "+ _presentCount);
            //keep going until if condition is reached; in this case more than 3 presents
        }
    }

    public void PlayerSpeed()
    {
        if (_presentCount <= 1)
        {
            //do nothing
        }

        else if (_presentCount == 2)
        {
            _player.speed = 5.5f;
        }

        else
        {
            _player.speed = 5f;
        }
    }
}
