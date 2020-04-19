using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Sc14 : MonoBehaviour
{
	public Image frame;
	public Image profile;
	public TextMeshProUGUI username;
	public TMP_InputField usernameEdit;
	public TextMeshProUGUI email;
	public TMP_InputField emailEdit;

	public Sprite[] frames;
	public Sprite[] profilePictures;

	private int m_frameIndex;

	private void OnEnable()
	{
		if (PlayerPrefs.GetInt("hp") >= 100)
		{
			m_frameIndex = 2;
		}

		if (PlayerPrefs.GetInt("hp") >= 350)
		{
			m_frameIndex = 4;
		}

		if (Database.HasDatabase())
		{
			var db = Database.Get();
			username.text = db.user.username;
			email.text = db.user.email;
			profile.overrideSprite = profilePictures[db.user.pictureId];
		}
	}

	public void Edit()
	{
		frame.overrideSprite = frames[m_frameIndex + 1];

		username.gameObject.SetActive(false);
		email.gameObject.SetActive(false);

		usernameEdit.gameObject.SetActive(true);
		usernameEdit.text = username.text;

		emailEdit.gameObject.SetActive(true);
		emailEdit.text = email.text;
	}

	public void ChangeInfo()
	{
		frame.overrideSprite = frames[m_frameIndex];

		emailEdit.gameObject.SetActive(false);
		usernameEdit.gameObject.SetActive(false);

		username.gameObject.SetActive(true);
		email.gameObject.SetActive(true);

		var db = Database.Get();
		db.user.username = usernameEdit.text;
		db.user.email = emailEdit.text;

		Database.Set(db);

		OnEnable();
	}

	/// <summary>
	/// /////////////////////////////////////////
	/// </summary>
	public UnityEvent onSuccessLogin1;

	public UnityEvent onSuccessLogin2;

	public GameObject[] password;

	private string passwordText = "";
	private string tempPassword = "";
	private int m_index = 0;

	private bool again = false;

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
			if (again)
			{
				if (tempPassword.Equals(passwordText))
				{
					var db = Database.Get();
					db.user.password = passwordText;
					Database.Set(db);

					ClearPassword();
					again = false;
					onSuccessLogin2.Invoke();
				}
				else
				{
					ClearPassword();
				}

				return;
			}

			tempPassword = passwordText;
			ClearPassword();
			again = true;
			onSuccessLogin1.Invoke();
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