using UnityEngine;
using EZCameraShake;

[RequireComponent(typeof(CameraShaker))]
public class MainCamShake : MonoBehaviour
{
    [SerializeField] private float magnitude = 5f;
    [SerializeField] private float roughness = 5f;
    [SerializeField] private float fadeInTime = .1f;
    [SerializeField] private float fadeOutTime = 1f;
    
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShakeCamera();
        }
    }*/

    public void ShakeCamera()
    {
        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
    }
}
