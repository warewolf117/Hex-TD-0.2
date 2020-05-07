using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Collections.Specialized;

public class MobileCameraControlBackup : MonoBehaviour
{

    private static readonly float PanSpeed = 5f;
    private static readonly float RotateSpeed = 1f;



    private static readonly float[] BoundsX = new float[] { -5f, 5f };
    private static readonly float[] BoundsZ = new float[] { -18f, -12f };

    private Camera cam;
    public GameObject target;
    public int CurrentPosition; // 0 = far out, 1=zoomed in hexes. 2=zoomed in lane
    private float CurrentFOV;
    private bool zoomingin;
    private bool zoomingout;
    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only




    void Start()
    {
        CurrentPosition = 0;
        Screen.SetResolution(1280, 720, true);
        // cam.aspect = 16 / 9;
    }
    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        CurrentFOV = cam.fieldOfView;
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }

        if (CurrentPosition == 0)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);
        }



        if (CurrentPosition == 1 && zoomingout == true)
        {
             Vector3 StartPosition2 = cam.transform.position;

             Vector3 move2 = new Vector3(0f, 18.5f, -7f);

             cam.transform.position = Vector3.Lerp(StartPosition2, move2, 0.2f);

             Quaternion StartRotation2 = cam.transform.rotation;

             Quaternion rotate2 = Quaternion.Euler(70f, 0f, 0f);

             cam.transform.rotation = Quaternion.Lerp(StartRotation2, rotate2, 0.2f);

             cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);
        }

        if (CurrentPosition == 1)
        {
            Vector3 StartPosition2 = cam.transform.position;

            Vector3 move2 = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition2, move2, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);
            return;
        }

        if (CurrentPosition == 2 && zoomingin == true)
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move1 = new Vector3(0f, 3f, 0f);

            cam.transform.position = Vector3.Lerp(StartPosition, move1, 0.2f);

            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate1 = Quaternion.Euler(15f, 30f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate1, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);
        }
        if (CurrentPosition == 0 && CurrentFOV >= 80f)
        {
            zoomingout = false;
        }

        if (CurrentPosition == 1 && CurrentFOV >= 36f)
        {
            zoomingout = false;
        }
        if (CurrentPosition == 2 && CurrentFOV >= 80f)
        {
            zoomingin = false;
        }




    }


    public void ZoomIn()
    {    

        if (CurrentPosition == 0)
        {
            CurrentPosition = 1;
            zoomingin = true;
            return;
        }

        if (CurrentPosition == 1)
        {
            CurrentPosition = 2;
            zoomingin = true;
        }
    }

    public void ZoomOut()
    {

        if (CurrentPosition == 1)
        {
            CurrentPosition = 0;
            zoomingout = true;
            return;
        }

        if (CurrentPosition == 2)
        {
            CurrentPosition = 1;
            zoomingout = true;

        }
    }

    void HandleTouch()
    {
        switch (Input.touchCount)
        {
            case 1: // Panning
                // If the touch began, capture its position and its finger ID.
                // Otherwise, if the finger ID of the touch doesn't match, skip it.
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                }
                else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved)
                {
                    RotateCamera(Input.GetTouch(0).deltaPosition.x);

                    if (CurrentPosition ==0)
                    {
                        PanCamera(touch.position);
                    }
                    
                }
                break;

        }
    }

    void HandleMouse()
    {
        // On mouse down, capture it's position.
        // Otherwise, if the mouse is still down, pan the camera.
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            RotateCamera(Input.GetAxis("Mouse X"));

            if (CurrentPosition == 0)
            {
                PanCamera(Input.mousePosition);
            }
            
        }

    }

    void RotateCamera(float newPanPosition)
    {
        // Determine how much to move the camera
        // Vector3 offset = cam.ScreenToWorldPoint(lastPanPosition - newPanPosition);
        if (CurrentPosition == 2)
        {
            Vector3 move = new Vector3(0, newPanPosition * RotateSpeed, 0);

            transform.Rotate(move, Space.World);
        }



    }

    void PanCamera(Vector3 newPanPosition)
    {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, 0, offset.y * PanSpeed);

        // Perform the movement
        transform.Translate(move, Space.World);

        // Ensure the camera remains within bounds.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        // Cache the position
        lastPanPosition = newPanPosition;
    }
}



