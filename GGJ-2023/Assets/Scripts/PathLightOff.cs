using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathLightOff : MonoBehaviour
{
    [SerializeField] private List<Light> lights;
    [SerializeField] private float fadeOutDuration = 0.3f;
    [SerializeField] private float waitForNextFadeDuration = 1;
    private int _lightIndex = 0;

    [SerializeField] private AudioSource audioSource;

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            NextFadeOut(0);
        }
    }*/

    public void NextFadeOut(int index)
    {
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(lights[index].DOIntensity(0, fadeOutDuration))
            .AppendInterval(waitForNextFadeDuration)
            .OnComplete(() =>
            {
                _lightIndex += 1;
                if(_lightIndex > lights.Count - 1) return;
                NextFadeOut(_lightIndex);
            });
    }
}
