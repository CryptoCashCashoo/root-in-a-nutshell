using UnityEngine;

public class Nutella : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody nutRB = other.gameObject.GetComponent<Rigidbody>();
            nutRB.angularVelocity = Vector3.zero;
            nutRB.angularDrag = 0f;
            nutRB.drag = 10f;
            GameManager.Get.WinGame();
        }
    }
}
