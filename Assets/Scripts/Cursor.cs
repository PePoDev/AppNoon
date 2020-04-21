using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Canvas myCanvas;

    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        myCanvas.GetComponent<Canvas>();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);
    }
}
