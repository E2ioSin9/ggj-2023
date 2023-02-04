using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private GameObject model;


    Coroutine flashingCoroutine;
    public void StartFlashing(float flashInterval)
    {
        model.gameObject.SetActive(true);

        if(flashingCoroutine != null)
        {
            StopCoroutine(flashingCoroutine);
        }
        flashingCoroutine = StartCoroutine(FlashingCoroutine(flashInterval));
    }

    public void StopFlashing()
    {
        model.gameObject.SetActive(true);

        if (flashingCoroutine != null)
        {
            StopCoroutine(flashingCoroutine);
        }
    }

    IEnumerator FlashingCoroutine(float interval)
    {
        WaitForSeconds flashInterval = new WaitForSeconds(interval);

        while (true)
        {
            model.gameObject.SetActive(true);

            yield return flashInterval;

            model.gameObject.SetActive(false);

            yield return flashInterval;
        }
    }
}
