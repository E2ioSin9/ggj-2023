using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent OnJumpScare;

    public void SuddenAppearHereAndDisappear()
    {
        monster.transform.position = transform.position;

        //Monster stop moving
        //Play scare audio
        OnJumpScare?.Invoke();
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

        OnJumpScare?.Invoke();

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