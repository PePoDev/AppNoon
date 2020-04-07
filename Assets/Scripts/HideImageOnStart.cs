using UnityEngine;
using UnityEngine.UI;

public class HideImageOnStart : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GetComponent<Image>());
    }
}
