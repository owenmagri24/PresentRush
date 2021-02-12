using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _menuBGM;
    private void Awake()
    {
        //keep music playing throughout scene changes; in this case: Menu and Instructions scene
        DontDestroyOnLoad(transform.gameObject);
        _menuBGM = GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        if (_menuBGM.isPlaying)
        {
            //if music is already playing; return
            return;
        }
        
        //if music is not playing; play it
        else
        {
            _menuBGM.Play();
        }
    }

    public void StopMusic()
    {
        //stop playing the menu BGM
        _menuBGM.Stop();
    }
}
