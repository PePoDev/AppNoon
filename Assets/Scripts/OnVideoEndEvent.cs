using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class OnVideoEndEvent : MonoBehaviour
{
    public UnityEvent onVideoEnd;
    
    private VideoPlayer m_videoPlayer;
    
    private void Awake()
    {
        m_videoPlayer = GetComponent<VideoPlayer>();
        m_videoPlayer.loopPointReached += (source) =>
        {
            onVideoEnd.Invoke();
            Destroy(this);
        };
    }
}
