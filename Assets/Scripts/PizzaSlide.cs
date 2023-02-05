using UnityEngine;
using UnityEngine.Events;

public class PizzaSlide : MonoBehaviour
{
    public UnityEvent<(GameObject player, GameObject piece)> _onCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _onCollision.Invoke((other.gameObject, this.transform.parent.gameObject));
    }
}
