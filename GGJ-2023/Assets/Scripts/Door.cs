using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool isLocked;
    [SerializeField] private Canvas info;

    [SerializeField] private AudioSource lockSFX;
    [SerializeField] private AudioSource openSFX;

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
            lockSFX.Play();

            CancelInvoke();
            Invoke(nameof(DisactiveInfoCanvas), 2f);
        }
        else
        {
            //door open
            doorTransform.DOLocalMoveZ(-19, 1);
            openSFX.Play();
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
