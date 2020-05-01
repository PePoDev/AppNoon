using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SFB;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UploadButton : MonoBehaviour, IPointerDownHandler
{

    public Sc12 sc12;

#if UNITY_WEBGL && !UNITY_EDITOR
    //
    // WebGL
    //
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

    public void OnPointerDown(PointerEventData eventData) {
        UploadFile(gameObject.name, "OnFileUpload", ".png, .jpg", false);
    }

    // Called from browser
    public void OnFileUpload(string url) {
        StartCoroutine(OutputRoutine(url));
    }
#else
    //
    // Standalone platforms & editor
    //
    public void OnPointerDown(PointerEventData eventData) { }

    void Start() {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", ".png, .jpg", false);
        if (paths.Length > 0) {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
#endif

    private IEnumerator OutputRoutine(string url) {
        var loader = new WWW(url);
        yield return loader;
        
        var texture = loader.texture;
        var s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        sc12.image.overrideSprite = s;

        var bytes = texture.EncodeToPNG();
        sc12.enc = Convert.ToBase64String(bytes);

        sc12.imageUploaded = true;
    }
}
