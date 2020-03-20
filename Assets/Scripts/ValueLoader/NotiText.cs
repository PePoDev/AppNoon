using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotiText : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("noti").ToString();
    }
}
