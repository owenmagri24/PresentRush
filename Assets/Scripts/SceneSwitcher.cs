using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private MusicManager _musicManager;

    //functions to run in the onClick() setting of each button
    public void InstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level");
        //stop playing menu BGM when clicking on the 'Play' button
        _musicManager.StopMusic();
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit Button has been pressed");
    }

    // Start is called before the first frame update
    void Start()
    {
        //finding object and then the script
        _musicManager = GameObject.Find("Menu_BGM").GetComponent<MusicManager>();
        //preventing crashes
        if (_musicManager == null)
        {
            Debug.LogError("Music Manager not found");
        }
        _musicManager.StartMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
