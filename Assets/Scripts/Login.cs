using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Login : MonoBehaviour
{
	public UnityEvent onSuccessLogin;
	public GameObject[] password;

	private int m_index = 0;

	public void EnterNumber(int number)
	{
		if (m_index > 3)
			return;
		
		password[m_index].SetActive(true);
		
		m_index++;
	}

	public void LoginButton()
	{
		if (m_index == 4)
			onSuccessLogin.Invoke();
	}

	public void ClearPassword()
	{
		foreach (var pw in password)
		{
			pw.SetActive(false);
		}

		m_index = 0;
	}
}