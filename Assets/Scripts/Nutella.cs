using UnityEngine;
using UnityEngine.Playables;

public class Nutella : MonoBehaviour
{

    PlayableDirector _timeline;
    void Awake()
    {
        _timeline = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody nutRB = other.gameObject.GetComponent<Rigidbody>();
            nutRB.angularVelocity = Vector3.zero;
            nutRB.angularDrag = 0f;
            nutRB.drag = 10f;
            GameManager.Get.FocusOnNutella();
            _timeline.Play();
        }
    }

    public void WinGame()
    {
        GameManager.Get.WinGame();
    }
}
