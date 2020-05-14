using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class UnitGhost : MonoBehaviour
{
    public GameObject Ghost;
    private bool dragGhost;
    Color OriginalColor = new Color(0, 0, 1, 0.75f);
    public static Material BlueTransparent;

    void Start()
    {
        BlueTransparent = Resources.Load("BlueTransparent", typeof(Material)) as Material;
        BlueTransparent.color = OriginalColor;
        Ghost = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Center")
        {
            BlueTransparent.color = new Color(1, 0, 0, 0.75f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        BlueTransparent.color = OriginalColor;
    }

    void Update()
    {

        if (Ghost == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    dragGhost = true;                   
                }
            }
        }
        

        if (Input.GetMouseButton(0))
        {
            if (dragGhost == true)        //update Ghost position
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
        }
        else
        {
            dragGhost = false;
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
