using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private string interactableTag = "Interactable";
    [SerializeField] private Interactable curInteractable;

    [SerializeField] private float rayDistance = 5f;

    [SerializeField] private GameObject pressEInfo;

    private Ray ray;

    private void Start()
    {
        pressEInfo.SetActive(false);
    }

    private void Update()
    {
        if (curInteractable != null)
        {
            curInteractable.HideHighlight();
            curInteractable = null;
            pressEInfo.SetActive(false);
        }

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, rayDistance))
        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.CompareTag(interactableTag))
            {
                curInteractable = hit.transform.GetComponent<Interactable>();
                curInteractable.ShowHighlight();
                pressEInfo.SetActive(true);
            }        
        }

        if (curInteractable != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                curInteractable.Interact();
            }
        }       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
