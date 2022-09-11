using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform playerFollowPos;

    [SerializeField] private Transform player;

    [SerializeField] private float followSmoothTime;

    private Vector3 _currentCamVelocity;
    
    private void Update()
    {
        cam.position = Vector3.SmoothDamp(cam.position, playerFollowPos.position, ref _currentCamVelocity, followSmoothTime);
        cam.LookAt(player);
    }
}
