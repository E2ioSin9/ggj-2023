using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;

    private bool isUsingCamera;

    private Vector3 cameraInitPos;
    [SerializeField] private Transform camNightVisionOnTransform;

    private Sway camSway;
    
    private AudioSource audioSource;

    private void Awake()
    {
        camSway = GetComponent<Sway>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        cameraInitPos = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!isUsingCamera) return;
            postProcessVolume.enabled = !postProcessVolume.enabled;

            if (postProcessVolume.enabled)
            {
                audioSource.Play();
                camSway.enabled = false;
                transform.DOLocalMove(camNightVisionOnTransform.localPosition, 0.5f);
            }
            else
            {
                camSway.enabled = true;
                transform.DOLocalMove(cameraInitPos, 0.5f);
            }
        }
    }
    
    public void EnableCamera()
    {
        isUsingCamera = true;
    }
    
    public void DisableCamera()
    {
        isUsingCamera = false;
        postProcessVolume.enabled = false;
    }
}
