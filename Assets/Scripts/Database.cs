using System;
using GameFlow;
using UnityEngine;

[Serializable]
public class Database
{
	public Notification[] notifications;
	public CakeItem cake;

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
	public int month;
	public string date;
	public string desc;
	public string path;
}

[Serializable]
public class CakeItem
{
	public int id;
	public int[] toppings;
}