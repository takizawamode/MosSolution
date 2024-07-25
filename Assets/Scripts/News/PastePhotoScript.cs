using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PastePhotoScript : MonoBehaviour
{
    public Image formPhoto;
    public GameObject Notification2;

    // Метод вызывается при нажатии кнопки загрузки изображения
    public void LoadImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                StartCoroutine(LoadImageTexture(path));
            }
        }, "Select a PNG image", "image/png");
    }

    IEnumerator LoadImageTexture(string path)
    {
        using (var www = new WWW("file://" + path))
        {
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                int maxWidth = 1280;
                int maxHeight = 720;

                if (www.texture.width < maxWidth || www.texture.height < maxHeight)
                {
                    Notification2.SetActive(true);
                }
                else
                {
                    Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
                    formPhoto.sprite = sprite;
                }
            }
        }
    }
}