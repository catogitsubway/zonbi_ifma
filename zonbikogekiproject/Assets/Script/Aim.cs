using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector3 normalPose, aimPose;
    public float aimSpeed;

    private Vector3 targetPose;

    public Camera cam;

    void Start()
    {
        targetPose = normalPose;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            targetPose = aimPose;
            cam.fieldOfView -= 40 * Time.deltaTime;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
        }
        else
        {
            targetPose = normalPose;
            cam.fieldOfView += 40 * Time.deltaTime;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPose, aimSpeed * Time.deltaTime);
    }
}
