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
            // Destroys present if player has less than 3presents. This way, the presents don't get destroyed if player has 3 presents already.
            Destroy(GameObject.FindWithTag("Present")); 
        }
    }

    public void ChildDestroy()
    {
        if(_presentCount  > 0)
        {
            Destroy(GameObject.FindWithTag("Children"));
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
