using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLookAt : MonoBehaviour
{
    public GameObject cameraTarget;
    public Camera cam;
    public bool smoothingActive = false;
    public float smoothSpeed = 0.01f, deadZoneX = 0.3f, deadZoneY = 0.3f;

    private float fov, hFov;
    private bool camLock = false;
    private Plane leftPlane, rightPlane, topPlane, bottomPlane;
    //private Vector3 offset;

    private void Start()
    {
        
    }

    public void OnEnable()
    {
        camLock = true;
    }

    public void OnDisable()
    {
        camLock = false;
    }

    public void LateUpdate()
    {
        if (camLock)
        {
            fov = cam.fieldOfView;
            hFov = fov * cam.aspect;

            Vector3 deltaVector = cameraTarget.transform.position - cam.transform.position;
            Vector3 targetScreenPosition = cam.WorldToScreenPoint(cameraTarget.transform.position);
            if (targetScreenPosition.x < Screen.width * deadZoneX || targetScreenPosition.x > Screen.width * (1 - deadZoneX) ||
                targetScreenPosition.y < Screen.height * deadZoneY || targetScreenPosition.y > Screen.height * (1 - deadZoneY))
            {
                cam.transform.forward = Vector3.Slerp(cam.transform.forward, deltaVector, 0.05f);
            }

            //leftPlane = new Plane(cam.transform.position, Vector3.Slerp(cam.transform.right, cam.transform.forward, (hFov / 2) / 90));
            //rightPlane = new Plane(cam.transform.position, Vector3.Slerp(-cam.transform.right, cam.transform.forward, (hFov / 2) / 90));
            //topPlane = new Plane(cam.transform.position, Vector3.Slerp(-cam.transform.up, cam.transform.forward, (fov / 2) / 90));
            //bottomPlane = new Plane(cam.transform.position, Vector3.Slerp(cam.transform.up, cam.transform.forward, (fov / 2) / 90));

            //Plane hPlane = new Plane(cam.transform.position, cam.transform.up);
            //Plane vPlane = new Plane(cam.transform.position, cam.transform.right);

            //Vector3 deltaVector = cameraTarget.transform.position - cam.transform.position;

            //if (!leftPlane.GetSide(cameraTarget.transform.position))
            //{
            //    if (!rightPlane.GetSide(cameraTarget.transform.position))
            //    {
            //        cam.transform.forward = Vector3.Slerp(cam.transform.forward, deltaVector, smoothSpeed);
            //    }
            //}
            //if (!topPlane.GetSide(cameraTarget.transform.position))
            //{
            //    if (!bottomPlane.GetSide(cameraTarget.transform.position))
            //    {
            //        cam.transform.forward = Vector3.Slerp(cam.transform.forward, deltaVector, smoothSpeed);
            //    }
            //}
        }
    }
}