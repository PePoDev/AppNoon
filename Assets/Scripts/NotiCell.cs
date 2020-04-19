using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotiCell : MonoBehaviour
{
	public TextMeshProUGUI day;
	public TextMeshProUGUI month;
	public TextMeshProUGUI date;
	public TextMeshProUGUI desc;
	public Image picture;

	public Toggle toggle;

	public Notification notiRef;
	
	private ScNoti m_scNoti;

	public bool temp;

	private void Start()
	{
		m_scNoti = FindObjectOfType<ScNoti>();
	}

	public void Update()
	{
		if (m_scNoti.isDeleting != temp)
		{
			toggle.gameObject.SetActive(m_scNoti.isDeleting);
			temp = m_scNoti.isDeleting;
		}
	}
}