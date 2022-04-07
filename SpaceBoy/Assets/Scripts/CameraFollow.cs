using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Transform ship;

    private void LateUpdate()
    {
        transform.position = ship.position + cameraOffset; //change camera's position according to the ship's position
    }
}
