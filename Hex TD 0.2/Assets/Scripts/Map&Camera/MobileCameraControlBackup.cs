using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Collections.Specialized;

public class MobileCameraControlBackup : MonoBehaviour
{

    private static readonly float PanSpeed = 5f;
    private static readonly float RotateSpeed = 0.2f;


    private static float BoundsX1 = -6f;
    private static float BoundsX2 = 6f;

    private static float BoundsY1 = -22.5f;
    private static float BoundsY2 = -2f;

    private  float[] BoundsX = new float[] { BoundsX1, BoundsX2 };
    private  float[] BoundsZ = new float[] { BoundsY1, BoundsY2 };

    private Camera cam;
    public GameObject target;
    public int CurrentPosition; // 0 = far out, 1=zoomed in hexes. 2=zoomed in lane
    private float CurrentFOV;
    public bool zoomingin;
    public bool zoomingout;
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
        BoundsX = new float[] { BoundsX1, BoundsX2 };
        BoundsZ = new float[] { BoundsY1, BoundsY2 };

    CurrentFOV = cam.fieldOfView;
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }

        if (CurrentPosition == 0 && CurrentFOV >= 80f)
        {
            zoomingout = false;
            zoomingin = false;
        }

        if (CurrentPosition == 1 && CurrentFOV <= 55.5f && CurrentFOV >= 55f)
        {
            zoomingin = false;
            zoomingout = false;
        }

        if (CurrentPosition == 2 && CurrentFOV <= 37f && CurrentFOV >= 36f)
        {
            zoomingin = false;
            zoomingout = false;
        }

        if (CurrentPosition == 3 && CurrentFOV >= 80f)
        {
            zoomingout = false;
            zoomingin = false;
        }

        if (CurrentPosition == 0 && zoomingout == true) //Going from Position 1 to Position 0
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(-4f, 18f, -6.5f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);
        }

        if (CurrentPosition == 1 && zoomingin == true) //Going from Position 0 to Position 1
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(-4f, 18f, -6.5f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 55.2f, 0.2f);

            return;
        }

        if (CurrentPosition == 1 && zoomingout == true) //Going from Position 2 to Position 1
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(-4f, 18f, -6.5f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.2f);

            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate = Quaternion.Euler(70f, 30f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 55.2f, 0.2f);
        }

        if (CurrentPosition == 2 && zoomingin == true) //Going from Position 1 to Position 2
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move = new Vector3(-4f, 18f, -5.7f);

            cam.transform.position = Vector3.Lerp(StartPosition, move, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);
            return;
        }

        if (CurrentPosition == 2 && zoomingout == true) //Going from Position 2 to Position 1
        {
             Vector3 StartPosition = cam.transform.position;

             Vector3 move = new Vector3(-4f, 18f, -6.5f);

             cam.transform.position = Vector3.Lerp(StartPosition, move, 0.2f);

             Quaternion StartRotation = cam.transform.rotation;

             Quaternion rotate = Quaternion.Euler(70f, 30f, 0f);

             cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate, 0.2f);

             cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);
        }


        if (CurrentPosition == 3 && zoomingin == true) //Going from Position 2 to Position 3
        {
            Vector3 StartPosition = cam.transform.position;

            Vector3 move1 = new Vector3(0f, 3f, 0f);

            cam.transform.position = Vector3.Lerp(StartPosition, move1, 0.2f);

            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate1 = Quaternion.Euler(15f, 30f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate1, 0.2f);

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);
        }
    }

    public void ZoomIn()
    {    

        if (CurrentPosition == 0)
        {
            BoundsX1 = -9f;
            BoundsX2 = 9f;

            BoundsY1 = -26.5f;
            BoundsY2 = 9f;

            CurrentPosition = 1;
            zoomingin = true;
            return;
        }

        if (CurrentPosition == 1)
        {

            BoundsX1 = -15f;
            BoundsX2 = 15f;

            BoundsY1 = -29f;
            BoundsY2 = 15f;

            CurrentPosition = 2;
            zoomingin = true;
            return;
        }


        if (CurrentPosition == 2)
        {
            CurrentPosition = 3;
            zoomingin = true;
            return;
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
            return;

        }

        if (CurrentPosition == 3)
        {
            CurrentPosition = 2;
            zoomingout = true;
            return;

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

                    if (CurrentPosition != 3)
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

            if (CurrentPosition != 3)
            {
                PanCamera(Input.mousePosition);
            }
            
        }

    }

    void RotateCamera(float newPanPosition)
    {
        // Determine how much to move the camera
        // Vector3 offset = cam.ScreenToWorldPoint(lastPanPosition - newPanPosition);
        if (CurrentPosition == 3)
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



