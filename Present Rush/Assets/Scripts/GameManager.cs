using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _presentCount;
    // Start is called before the first frame update
    void Start()
    {
        _presentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectedPresent()
    {
        _presentCount++;
        Debug.Log("Present Count: " + _presentCount);
    }
}
