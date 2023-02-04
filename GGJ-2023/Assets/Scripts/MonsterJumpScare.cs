using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJumpScare : MonoBehaviour
{

    [SerializeField] private MonsterController monster;
    [SerializeField] private AudioClip scareSFX;

    [Header("FlyToForward")]
    [SerializeField] private float waitFlySeconds;
    [SerializeField] private float flySpeed;
    [SerializeField] private float flyDuration;

    [SerializeField] private bool isFlashingMonster = false;
    [SerializeField] private float flashingInterval;

    Coroutine flyForwardCoroutine;

    public void SuddenAppearHereAndDisappear()
    {
        monster.transform.position = transform.position;

        //Monster stop moving
        //Play scare audio
    }

    [ContextMenu("StartFlyToForward")]
    public void StartFlyToForward()
    {
        monster.StopFlashing();

        if(flyForwardCoroutine != null)
        {
            StopCoroutine(flyForwardCoroutine);
        }

        flyForwardCoroutine = StartCoroutine(FlyForwardCoroutine());
    }

    IEnumerator FlyForwardCoroutine()
    {
        monster.transform.position = transform.position;
        monster.transform.rotation = Quaternion.LookRotation(transform.forward);

        yield return new WaitForSeconds(waitFlySeconds);

        if (isFlashingMonster)
        {
            monster.StartFlashing(flashingInterval);
        }

        float t = 0f;

        while (t < flyDuration)
        {
            monster.transform.Translate(monster.transform.forward * flySpeed * Time.deltaTime);

            t += Time.deltaTime;

            yield return null;
        }

        monster.StopFlashing();
    }
}