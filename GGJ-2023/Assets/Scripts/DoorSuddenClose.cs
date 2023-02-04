using DG.Tweening;
using UnityEngine;

public class DoorSuddenClose : MonoBehaviour
{
    [SerializeField] private float closeDoorDuration = 0.2f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(2))
        {
            _audioSource.Play();
            transform.DOLocalRotate(new Vector3(-90, 0, 90), closeDoorDuration);
        }*/
    }

    public void CloseDoorSudden()
    {
        Debug.Log("Test");
        _audioSource.Play();
        transform.DOLocalRotate(new Vector3(-90, 0, 90), closeDoorDuration);
    }
}
