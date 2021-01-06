using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _childrenPrefab; //created game object for children prefab

    [SerializeField]
    private GameObject _childrenContainer; //created children container to use as parent

    private bool _stopSpawning = false; //Created boolean to be used to stop spawning when player loses

    // Start is called before the first frame update
    void Start()
    {
        //calling spawning function
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to spawn Children
    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false) //loop will happen until _stopSpawning == true
        {
            //random position coordinates will be between -8.1f and 8.1f for x and -4.2f and 4.2f for y. 
            // Avoided using the exact coordinates of map boundary
            Vector2 posToSpawn = new Vector2(Random.Range(-8.1f,8.1f),Random.Range(-4.2f,4.2f)); 
            //Spawn a child and store it in newChild
            GameObject newChild = Instantiate(_childrenPrefab, posToSpawn, Quaternion.identity);
            //Set newChild as a child to ChildrenContainer
            newChild.transform.SetParent(_childrenContainer.transform);
            //Wait 7seconds before spawning next child
            yield return new WaitForSeconds(3f);
        }
    }
}
