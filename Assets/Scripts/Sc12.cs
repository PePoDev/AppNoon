using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Text;

public class Sc12 : MonoBehaviour
{
	public GameObject uploadButton;

	public Image image;
	public TMP_InputField story;

	public bool imageUploaded;

	public string enc;
	public UnityEvent onShared;

	public void Share()
	{
		if (imageUploaded)
		{
			var db = Database.Get();

			var post = new Post()
			{
				date = DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture),
				image = enc,
				name = db.user.username,
				react1 = false,
				react2 = false,
				react3 = false,
				story = story.text,
				picId = db.user.pictureId
			};

			db.posts.Add(post);
			Database.Set(db);

			onShared.Invoke();
		}
	}

	public void AddScore()
	{
		var db = Database.Get();

		var notification = new Notification()
		{
			date = DateTime.Now.ToString("dd MMM : hh.mm tt", CultureInfo.InvariantCulture),
			day = DateTime.Now.Day,
			month = DateTime.Now.ToString("MMM", CultureInfo.InvariantCulture),
			desc = $"ได้รับคะแนนสะสม 1 Pt",
			pictureId = 11
		};

		db.notifications.Add(notification);
		PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + 1);
		PlayerPrefs.Save();

		Database.Set(db);
	}
}