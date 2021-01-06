using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField]
    private float despawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, despawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if player picks up present, present is destroyed
        if(other.transform.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
