using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float FollowSpeed = 2f;
    [SerializeField]
    private float yOffset = 1f;
    [SerializeField]
    private Transform target;

    private ICameraUtility _cameraUtility;
    void Start()
    {
        _cameraUtility = new CameraUtility(); 
    }

    // Update is called once per frame
    void Update()
    {
        _cameraUtility.moveCameraSmooth(target, transform, yOffset, FollowSpeed);
    }
}
