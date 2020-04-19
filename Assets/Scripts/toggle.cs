using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
	public GameObject on, off;

	public void OnToggle()
	{
		var temp = on.activeSelf;
		on.SetActive(!temp);
		off.SetActive(temp);
	}
}