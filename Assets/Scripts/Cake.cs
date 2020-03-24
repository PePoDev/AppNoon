using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
	public Sprite[] cakes;

	public Transform[] toppings;

	public void OnEnable()
	{
		var db = Database.Get();

		GetComponent<Image>().overrideSprite = cakes[db.cake.id];

		foreach (var t in toppings)
		{
			foreach (Transform child in t)
			{
				Destroy(child.gameObject);
			}

			t.gameObject.SetActive(true);
		}

		for (var i = 0; i < db.cake.toppings.Length; i++)
		{
			if (db.cake.toppings[i] == 0)
			{
				toppings[i].gameObject.SetActive(false);
			}
			else
			{
				var newPos = toppings[i].GetComponent<RectTransform>().anchoredPosition;
				for (var j = 1; j < db.cake.toppings[i]; j++)
				{
					newPos.x += 5;
					newPos.y += 5;
					Instantiate(toppings[i].gameObject, newPos, toppings[i].rotation, toppings[i]);
				}
			}
		}
	}

	public void AddToppingId(int id)
	{
		var db = Database.Get();

		db.cake.toppings[id]++;

		Database.Set(db);

		OnEnable();
	}
}