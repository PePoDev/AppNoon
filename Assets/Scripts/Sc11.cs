using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc11 : MonoBehaviour
{
	
	public PostCell cell;
	public Transform content;

	public Sprite[] pictures;
	
	private void OnEnable()
	{
		foreach (Transform o in content)
		{
			Destroy(o.gameObject);
		}

		if (Database.HasDatabase())
		{
			var db = Database.Get();
			foreach (var post in db.posts)
			{
				var p = Instantiate(cell, content, false);
				p.date.text = post.date;

				byte[] imageBytes = Convert.FromBase64String(post.image);
				Texture2D tex = new Texture2D(2, 2);
				tex.LoadImage(imageBytes);
				Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

				p.image.overrideSprite = sprite;
				p.name.text = post.name;
				p.react1.overrideSprite = post.react1 ? p.on : p.off;
				p.react2.overrideSprite = post.react2 ? p.on : p.off;
				p.react3.overrideSprite = post.react3 ? p.on : p.off;
				p.story.text = post.story;
				p.picture.overrideSprite = pictures[post.picId];
				p.db = db;
				p.post = post;
			}
		}
	}
}
