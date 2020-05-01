using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using GameFlow;
using UnityEngine;

[Serializable]
public class Database
{
	public List<Notification> notifications;
	public List<Post> posts;
	public CakeItem cake;

	public CakeItem[] cakes;
	public ToppingHistory[] toppingHistory;

	public User user;

	[DllImport("__Internal")]
	private static extern void SyncFiles();

	[DllImport("__Internal")]
	private static extern void WindowAlert(string message);

	private static readonly string SaveFile = "{0}/save.dat";

	public static Database Get()
	{
		Database database = null;
		var dataPath = string.Format(SaveFile, Application.persistentDataPath);

		try
		{
			if (File.Exists(dataPath))
			{
				var readText = File.ReadAllText(dataPath);
				database = JsonUtility.FromJson<Database>(readText);
			}
		}
		catch (Exception e)
		{
			PlatformSafeMessage("Failed to Load: " + e.Message);
		}

		return database;
	}

	public static void Set(Database database)
	{
		var dataPath = string.Format(SaveFile, Application.persistentDataPath);

		try
		{
			if (File.Exists(dataPath))
			{
				File.Delete(dataPath);
			}

			File.WriteAllText(dataPath, JsonUtility.ToJson(database));  

			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				SyncFiles();
			}
		}
		catch (Exception e)
		{
			PlatformSafeMessage("Failed to Save: " + e.Message);
		}
	}

	public static void Reset()
	{
		var dataPath = string.Format(SaveFile, Application.persistentDataPath);
		try
		{
			if (File.Exists(dataPath))
			{
				File.Delete(dataPath);
			}
			
			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				SyncFiles();
			}
		}
		catch (Exception e)
		{
			PlatformSafeMessage("Failed to Save: " + e.Message);
		}
	}

	public static bool HasDatabase()
	{
		var hasDb = false;
		try
		{
			hasDb = File.Exists(string.Format(SaveFile, Application.persistentDataPath));
		}
		catch (Exception e)
		{
			PlatformSafeMessage("Failed to Save: " + e.Message);
		}

		return hasDb;
	}

	public static void PlatformSafeMessage(string message)
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			WindowAlert(message);
		}
		else
		{
			Debug.Log(message);
		}
	}
}

[Serializable]
public class Notification
{
	public int day;
	public string month;
	public string date;
	public string desc;
	public int pictureId;
}

[Serializable]
public class Post
{
	public int picId;
	public string name;
	public string date;
	public string story;
	public string image;
	public bool react1;
	public bool react2;
	public bool react3;
}

[Serializable]
public class CakeItem
{
	public int id;
	public int[] toppings;
}

[Serializable]
public class User
{
	public int pictureId;
	public string password;
	public string username;
	public string email;
}

[Serializable]
public class ToppingHistory
{
	public int[] pictureGroup;
	public int[] pictureId;
	public int[] days;
	public string[] decs;
	public string[] hp;
}