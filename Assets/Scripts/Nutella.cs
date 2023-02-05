using UnityEngine;

public class Nutella : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Get.WinGame();
    }
}
