using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (Database.HasDatabase() == false)
        {
            var db = new Database {cake = new CakeItem{toppings = new int[6]}};
            PlayerPrefs.SetString("database", JsonUtility.ToJson(db));
            PlayerPrefs.Save();
        }
    }
}
