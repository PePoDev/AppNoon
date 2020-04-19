using System;
using System.Collections;
using System.Collections.Generic;
using GameFlow;
using UnityEngine;

public class ScNoti : MonoBehaviour
{

    public NotiCell cell;
    public Transform content;

    public bool isDeleting = false;

    public Sprite[] pictures;

    private List<NotiCell> m_allNoti = new List<NotiCell>();

    public Database db;
    
    public void OnEnable()
    {
        foreach (Transform o in content)
        {
            Destroy(o.gameObject);
        }

        db = Database.Get();

        foreach (var noti in db.notifications)
        {
            var n = Instantiate(cell, content, false);
            n.day.text = noti.day.ToString();
            n.month.text = noti.month;
            n.date.text = noti.date;
            n.desc.text = noti.desc;
            n.picture.overrideSprite = pictures[noti.pictureId];
            n.notiRef = noti;
            
            m_allNoti.Add(n);
        }
    }

    public void Delete()
    {
        if (isDeleting)
        {
            var temp = new List<NotiCell>();
            foreach (var o in m_allNoti)
            {
                if (o.toggle.isOn)
                {
                    temp.Add(o);
                    Destroy(o.gameObject);
                }
            }

            foreach (var o in temp)
            {
                db.notifications.Remove(o.notiRef);
                
                Debug.Log("Total noti " + db.notifications.Count);
                
                m_allNoti.Remove(o);
                
                Database.Set(db);
            }

            isDeleting = false;
        }
        else
        {
            isDeleting = true;
        }
    }
}
