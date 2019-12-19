using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageDownloader : MonoBehaviour
{
    public InputField field;
    public RawImage img;

    public void Download()
    {
        StartCoroutine(DownloadImage(field.text));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            img.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}