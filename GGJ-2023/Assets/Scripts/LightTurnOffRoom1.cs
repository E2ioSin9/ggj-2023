using DG.Tweening;
using UnityEngine;

public class LightTurnOffRoom1 : MonoBehaviour
{
    [SerializeField] private Light light;
    private float _initialIntensity;

    [SerializeField] private float waitForSecondsTrigger = 5;
    [SerializeField] private float lowLightIntensity = 3;
    [SerializeField] private float lightFlashDuration = 0.2f;
    [SerializeField] private float fadeOutIntensity = 2;
    [SerializeField] private float fadeOutDuration = 0.5f;
    [SerializeField] private float lightTurnOffDuration = 0.05f;

    [SerializeField] private GameObject root;

    private void Start()
    {
        root.SetActive(false);
        _initialIntensity = light.intensity;
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            DOTween.Sequence()
                .AppendInterval(10)
                .Append(light.DOIntensity(lowLightIntensity, lightFlashDuration))
                .Append(light.DOIntensity(_initialIntensity, lightFlashDuration))
                .Append(light.DOIntensity(lowLightIntensity, lightFlashDuration))
                .Append(light.DOIntensity(_initialIntensity, lightFlashDuration))
                .Append(light.DOIntensity(fadeOutIntensity, fadeOutDuration))
                .Append(light.DOIntensity(0, lightTurnOffDuration)).OnComplete(() =>
                {
                    root.SetActive(true);
                });
        }
    }*/

    public void TriggerOffLight()
    {
        DOTween.Sequence()
            .AppendInterval(waitForSecondsTrigger)
            .Append(light.DOIntensity(lowLightIntensity, lightFlashDuration))
            .Append(light.DOIntensity(_initialIntensity, lightFlashDuration))
            .Append(light.DOIntensity(lowLightIntensity, lightFlashDuration))
            .Append(light.DOIntensity(_initialIntensity, lightFlashDuration))
            .Append(light.DOIntensity(fadeOutIntensity, fadeOutDuration))
            .Append(light.DOIntensity(0, lightTurnOffDuration)).OnComplete(() =>
            {
                root.SetActive(true);
            });
    }
}
