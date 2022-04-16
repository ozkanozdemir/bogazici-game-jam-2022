using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] Vector3 targetedPosition;
    [SerializeField] float smoothTime = 0.3f;

    private Vector3 _velocity = Vector3.zero;
    
    // Update is called once per frame
    void LateUpdate()
    {
        // Kameranın yumuşak geçişlerle player objesini takip etmesi
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref _velocity, smoothTime);
    }
}
