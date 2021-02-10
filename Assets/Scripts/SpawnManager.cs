using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _childrenPrefab; //created game object for children prefab
    [SerializeField]
    private GameObject _presentPrefab; //created game object for present prefab

    [SerializeField]
    private GameObject _childrenContainer; //created children container to use as parent
    [SerializeField]
    private GameObject _presentContainer; //created present container to use as parent

    private bool _stopSpawning = false; //Created boolean to be used to stop spawning when player loses

    // Start is called before the first frame update
    void Start()
    {
        //calling spawning function
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnRoutineTwo());
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
            yield return new WaitForSeconds(2.2f);
        }
    }

    //Function to spawn Presents
    IEnumerator SpawnRoutineTwo()
    {
        while(_stopSpawning == false)
        {
            //presents will spawn between the range of (X -8.1f and 8.1f) and (Y -4.2f and 4.2f)
            Vector2 posToSpawn = new Vector2(Random.Range(-8.1f,8.1f),Random.Range(-4.2f,4.2f));
            //spawns a present prefab
            GameObject newPresent = Instantiate(_presentPrefab, posToSpawn, Quaternion.identity);
            //stores the present prefab in the PresentContainer
            newPresent.transform.SetParent(_presentContainer.transform);
            //wait 2 seconds before spawning next present
            yield return new WaitForSeconds(1.9f);
        }
    }

    //stops spawning children and presents
    public void PlayerDies()
    {
        _stopSpawning = true;
    }
}
