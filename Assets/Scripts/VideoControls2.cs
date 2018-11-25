using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControls2 : MonoBehaviour {

    public VideoPlayer video1;
    private void Awake()
    {
        video1.GetComponent<VideoPlayer>();
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
        }
        else
        {
            video1.Play();
        }
    }
}
