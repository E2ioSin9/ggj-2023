using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] private string triggerTag;

    [SerializeField] private UnityEvent TriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            TriggerEnterEvent?.Invoke();
        }
    }
}
