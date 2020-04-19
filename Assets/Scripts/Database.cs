using System;
using System.Collections.Generic;
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
	
	public static Database Get()
	{
		return JsonUtility.FromJson<Database>(PlayerPrefs.GetString("database"));
	}

	public static void Set(Database database)
	{
		PlayerPrefs.SetString("database", JsonUtility.ToJson(database));
		PlayerPrefs.Save();
	}

	public static bool HasDatabase()
	{
		return PlayerPrefs.HasKey("database");
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