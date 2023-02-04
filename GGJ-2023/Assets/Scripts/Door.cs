using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool isLocked;
    [SerializeField] private Canvas info;

    [SerializeField] private Transform doorTransform;

    private void Start()
    {
        isLocked = true;
        DisactiveInfoCanvas();
    }

    public override void Interact()
    {
        if (isLocked)
        {
            info.gameObject.SetActive(true);

            CancelInvoke();
            Invoke(nameof(DisactiveInfoCanvas), 2f);
        }
        else
        {
            //door open
            doorTransform.DOLocalMoveZ(-19, 1);
        }
    }

    private void DisactiveInfoCanvas()
    {
        info.gameObject.SetActive(false);
    }

    public void UnLockDoor()
    {
        isLocked = false;
    }

}
