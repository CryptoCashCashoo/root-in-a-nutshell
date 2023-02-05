using UnityEngine;
using UnityEngine.Events;

public class PizzaSlide : MonoBehaviour
{
    public UnityEvent _onCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _onCollision.Invoke();
    }
}
