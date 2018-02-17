using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour {
    [Tooltip("The target transform to follow.")]
    [SerializeField] Transform target = null;
    [Tooltip("duration of the camera to line up with the target.")]
    [SerializeField] float lerp = 1;
    [Tooltip("minimum speed of the camera to follow the target.")]
    [SerializeField] float minSpeed = 1;
    
    [Tooltip("Global minimum y value of the cameras position.")]
    [SerializeField] float yMin = 0;
    [Tooltip("Global maximum y value of the cameras postion.")]
    [SerializeField] float yMax = 10;

    static CameraController instance;
    Vector3 offset;

    void Awake()
    {
        offset = new Vector3(0, 0, transform.position.z);
        instance = this;
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 newPos = transform.position;
        Vector3 targetPosition = target.position + offset;
        Vector3 targetLerp = Vector3.Lerp(newPos, targetPosition, Time.deltaTime * lerp);

        if ((newPos - targetLerp).magnitude > minSpeed * Time.deltaTime)
        {
            newPos = targetLerp;
        }
        else if ((newPos - targetPosition).magnitude > minSpeed * Time.deltaTime)
        {
            Vector3 targetDir = targetPosition - newPos;
            targetDir.Normalize();
            newPos += targetDir * (Time.deltaTime * minSpeed);
        }
        newPos.x = Mathf.Clamp(newPos.x, 0, 0);
        newPos.y = Mathf.Clamp(newPos.y, yMin, yMax);

        transform.position = newPos;
    }

}
