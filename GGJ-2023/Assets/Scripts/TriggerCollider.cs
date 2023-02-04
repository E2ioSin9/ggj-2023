using UnityEngine;
using UnityEngine.Events;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] private string triggerTag;

    [SerializeField] private UnityEvent TriggerEnterEvent;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            TriggerEnterEvent?.Invoke();
            _boxCollider.enabled = false;
        }
    }
}
