using UnityEngine;
using TMPro;

public class HpText : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("hp").ToString() + " HP";
    }
}
