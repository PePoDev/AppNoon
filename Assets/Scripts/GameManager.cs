using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("database") == false)
        {
            PlayerPrefs.SetString("database", JsonUtility.ToJson(new Database()));
            PlayerPrefs.Save();
        }
    }
}
