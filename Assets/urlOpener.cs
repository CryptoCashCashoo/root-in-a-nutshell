using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class urlOpener : MonoBehaviour
{
    public string _url;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener((() => OpenUrl(_url)));
    }

    static void OpenUrl(string url) { Application.OpenURL(url); }
}
