using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public string[] pathFiles;
    private VideoPlayer videoPlayer;
    private int currentVideoIndex = 0;
    public GameObject button;

    void Start()
    {
        button.SetActive(false);
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.loopPointReached += ShowButton;

        if (pathFiles.Length > 0)
        {
            PlayVideo(0);
        }
    }

    void ShowButton(VideoPlayer vp)
    {
        button.SetActive(true);
    }

    public void OnClick()
    {
        button.SetActive(false);
        OnVideoFinished();
    }

    void OnVideoFinished()
    {
        int nextIndex = currentVideoIndex + 1;
        if (nextIndex < pathFiles.Length)
        {
            PlayVideo(nextIndex);
        }
    }

    void PlayVideo(int index)
    {
        if (index < pathFiles.Length)
        {
            videoPlayer.url = pathFiles[index];
            videoPlayer.Play();
            currentVideoIndex = index;
            
        }
    }
}
