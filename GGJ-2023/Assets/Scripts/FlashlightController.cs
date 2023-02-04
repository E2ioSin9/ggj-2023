using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Light light;
    private AudioSource audioSource;

    public bool isUsingFlashLight = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!isUsingFlashLight) return;
            audioSource.Play();
            light.enabled = !light.enabled;
        }
    }

    public void EnableFlashLight()
    {
        isUsingFlashLight = true;
    }
    
    public void DisableFlashLight()
    {
        isUsingFlashLight = false;
        light.enabled = false;
    }
}
