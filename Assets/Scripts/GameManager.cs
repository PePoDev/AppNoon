using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private void Awake()
	{
		if (Database.HasDatabase() == false)
		{
			var db = new Database
			{
				cake = new CakeItem
				{
					id = -1,
					toppings = new int[6]
				},
				cakes = new[]
				{
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
					new CakeItem
					{
						id = -1,
						toppings = new int[6]
					},
				},
				toppingHistory = new ToppingHistory[12]
				{
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
					new ToppingHistory()
					{
						pictureGroup = new int[31],
						pictureId = new int[31],
						days = new int[31],
						decs = new string[31],
						hp = new string[31],
					},
				},
				notifications = new List<Notification>(),
				user = new User
				{
					email = "",
					password = "",
					username = "",
					pictureId = 0
				},
				posts = new List<Post>(),
			};
			Database.Set(db);
		}
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.X))
		{
			Database.Reset();
			Awake();
		}
	}
}