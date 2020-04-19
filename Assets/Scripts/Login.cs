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

	private string passwordText = "";
	private int m_index = 0;

	public void EnterNumber(int number)
	{
		if (m_index > 3)
			return;

		password[m_index].SetActive(true);
		passwordText += number.ToString();
		
		m_index++;
	}

	public void LoginButton()
	{
		if (m_index == 4)
		{
			var db = Database.Get();
			if (passwordText.Equals(db.user.password))
			{
				onSuccessLogin.Invoke();
			}
			else
			{
				ClearPassword();
			}
			
		}
	}

	public void ClearPassword()
	{
		foreach (var pw in password)
		{
			pw.SetActive(false);
		}

		passwordText = "";
		m_index = 0;
	}
}