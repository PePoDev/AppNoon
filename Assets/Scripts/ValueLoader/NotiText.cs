using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotiText : MonoBehaviour
{
    private void OnEnable()
    {
        if (!Database.HasDatabase())
        {
            return;
        }
        var db = Database.Get();
        GetComponent<TextMeshProUGUI>().text = db.notifications.Count.ToString();
    }
}
