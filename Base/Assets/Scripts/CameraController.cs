﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour {
    [Tooltip("The target transform to follow.")]
    [SerializeField] Transform target = null;
    [SerializeField] float minSpeed = 5;
    
    [Tooltip("Global maximum y value of the cameras postion.")]
    [SerializeField] float yMin = 0;
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

        //Vector3 newPos = transform.position;
        //Vector3 

        Vector3 newPos = transform.position;
        Vector3 targetPosition = target.position + offset;
        //Vector3 targetLerp = Vector3.Lerp(newPos, targetPosition, Time.deltaTime * lerp);

        //if ((newPos - targetLerp).magnitude > minSpeed * Time.deltaTime)
        //{
        //    newPos = targetLerp;
        //}
        if ((newPos - targetPosition).magnitude > minSpeed * Time.deltaTime)
        {
            Vector3 targetDir = targetPosition - newPos;
            targetDir.Normalize();
            newPos += targetDir * (Time.deltaTime * minSpeed);
        }
        newPos.x = 0;
        newPos.y = Mathf.Clamp(newPos.y, yMin, yMax);
        
        transform.position = newPos;
    }

}
