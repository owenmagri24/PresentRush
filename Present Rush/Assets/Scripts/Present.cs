using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField]
    //setting the amount of time presents need to despawn
    private float despawn = 5f;

    public static int presentCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //present counter is set to 0
        presentCount = 0;
        //start the despawn timer
        Destroy(this.gameObject, despawn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) 
    {
        //if player picks up present, present is destroyed (still need to add to console counter)
        if(other.transform.name == "Player")
        {
            presentCount++;
            Debug.Log("Present Count: "+ presentCount);
            Destroy(this.gameObject);
        }
    }
}
