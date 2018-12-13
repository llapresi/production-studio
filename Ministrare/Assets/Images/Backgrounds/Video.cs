using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour {

    public RawImage image;

    private VideoPlayer videoPlayer;
    public VideoClip videoToPlay;
    private VideoSource videoSource;

	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        StartCoroutine(playVideo());

    }

    // Update is called once per frame
    void Update () {
		
	}
    IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();


        videoPlayer.playOnAwake = false;
        //We want to play from video clip not from url

        videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        //videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        videoPlayer.isLooping = true;
    }
}
