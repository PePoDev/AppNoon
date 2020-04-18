using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class day : MonoBehaviour
{
    public int index;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        FindObjectOfType<Sc10>().OpenDialog(index);
    }
}
