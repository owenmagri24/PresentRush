using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //functions to run in the onClick() setting of each button
    public void InstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level");
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
