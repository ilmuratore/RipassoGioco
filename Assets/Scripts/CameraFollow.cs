using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Target")]
    [SerializeField] private Transform target;


    [Header("Impostazioni")]
    [SerializeField] private float smoothing = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 posizioneDesiderata = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, posizioneDesiderata, smoothing * Time.deltaTime);
    }

}
