using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] Vector3 targetedPosition;
    [SerializeField] float smoothTime = 0.3f;
    
    [SerializeField] float positionMinX;
    [SerializeField] float positionMaxX;
    [SerializeField] float positionMinY;
    [SerializeField] float positionMaxY;

    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetObject)
        {
            // Kameranın yumuşak geçişlerle player objesini takip etmesi
            float targetObjectPositionX = targetObject.transform.position.x;
            float targetObjectPositionY = targetObject.transform.position.y;
        
            float camX = Mathf.Clamp(targetObjectPositionX, positionMinX, positionMaxX);
            float camY = Mathf.Clamp(targetObjectPositionY, positionMinY, positionMaxY);
        
            targetedPosition = new Vector3(camX, camY) + cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref _velocity, smoothTime);   
        }
    }
}
