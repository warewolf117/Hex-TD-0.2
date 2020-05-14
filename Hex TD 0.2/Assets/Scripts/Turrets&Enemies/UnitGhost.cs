using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UnitGhost : MonoBehaviour
{
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            MobileCameraControlBackup.cantPan = true;
            float planeY = 0.85f;
            Transform draggingObject = transform;

            Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance); // distance along the ray
            }
        }
        else
        {
            transform.position = new Vector3(-0.02f, 0.85f, 0f);
            MobileCameraControlBackup.cantPan = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(this.gameObject);
            BuildManager.GhostActive = false;
            MobileCameraControlBackup.cantPan = false;
        }
    }
}
