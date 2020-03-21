using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
	public Sprite[] cakes;

	public Sprite[] Toppings;
    public void OnEnable()
    {
	    GetComponent<Image>().overrideSprite = cakes[PlayerPrefs.GetInt("mainCake")];
    }

    public void AddToppingId(int id)
    {
	    
    }
}
