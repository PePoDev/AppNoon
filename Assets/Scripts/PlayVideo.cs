using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
	public string filename;

	private VideoPlayer m_videoPlayer;

	private void Awake()
	{
		m_videoPlayer = GetComponent<VideoPlayer>();
		m_videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,$"videos/{filename}.mp4");
		m_videoPlayer.Prepare();
	}

	// private void Start()
	// {
	// 	m_videoPlayer.Play();
	// }

	private void OnEnable()
	{
		m_videoPlayer.Play();
	}
}
