using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControls2 : MonoBehaviour {

    public VideoPlayer video1;
    public GameObject botonPlay; //icono de play cuando se pausa
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayPauseVideo()
    {
        if (video1.isPlaying)
        {
            video1.Pause();
            botonPlay.SetActive(true);
        }
        else
        {
            video1.Play();
            botonPlay.SetActive(false);
        }
    }

    public bool isItPlaying()
    {
        return video1.isPlaying;
    }
}
