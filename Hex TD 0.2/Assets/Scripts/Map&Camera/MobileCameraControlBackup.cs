using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Collections.Specialized;

public class MobileCameraControlBackup : MonoBehaviour
{

    private static readonly float PanSpeed = 2f;
    private static readonly float ZoomSpeedTouch = 0.5f;
    private static readonly float ZoomSpeedMouse = 5f;

    private static readonly float[] BoundsX = new float[] { -3f, 3f };
    private static readonly float[] BoundsZ = new float[] { -12f, -6f };
    private static readonly float[] ZoomBounds = new float[] { 20f, 80f };

    private Camera cam;
    public GameObject target;
    public float CurrentFOV;
    public int CurrentPosition; // 0 = far out, 1=zoomed in hexes. 2=zoomed in lane
    private bool ZoomingIn;
    private bool ZoomingOut;
    private float OldFOV;
    private bool zoomtrue;


    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only

    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only


    
    void Start()
    {
        CurrentFOV = cam.fieldOfView;
        CurrentPosition = 0;
        ZoomingOut = false;
        ZoomingIn = false;
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


        if ( CurrentFOV >= 80f && CurrentPosition == 1 && ZoomingIn == true && CurrentPosition != 2)
        {
            CurrentPosition = 2;
            ZoomingIn = false;
            ZoomingOut = false;

        }

        if (CurrentFOV <= 37f && CurrentFOV >= 36f && CurrentPosition != 1)
        {
            
            CurrentPosition = 1;
            ZoomingIn = false;
            ZoomingOut = false;

        }

        if (CurrentFOV >= 80f && CurrentPosition != 0 && ZoomingOut == true && CurrentPosition != 2 )
        {
            CurrentPosition = 0;
            ZoomingIn = false;
            ZoomingOut = false;

        }

        if (CurrentPosition == 0 && ZoomingOut == false && ZoomingIn == true && zoomtrue == true)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);
            zoomtrue = false;

            return;
        }

        if (CurrentPosition == 1 && ZoomingIn == false && ZoomingOut == true && zoomtrue == true)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);
            zoomtrue = false;
            return;
        }

        if (CurrentPosition == 1 && ZoomingIn == true && ZoomingOut == false && zoomtrue == true)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80.5f, 0.2f);

            Vector3 StartPosition = cam.transform.position;

            Vector3 move1 = new Vector3(0f, 3f, 0f);

            cam.transform.position = Vector3.Lerp(StartPosition, move1, 0.2f);

            Quaternion StartRotation = cam.transform.rotation;

            Quaternion rotate1 = Quaternion.Euler(15f, 30f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation, rotate1, 0.2f);
            zoomtrue = false;
            return;
        }

        if (CurrentPosition == 2 && ZoomingIn == false && ZoomingOut == true && zoomtrue == true)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 36.5f, 0.2f);

            Vector3 StartPosition2 = cam.transform.position;

            Vector3 move2 = new Vector3(0f, 18.5f, -7f);

            cam.transform.position = Vector3.Lerp(StartPosition2, move2, 0.2f);

            Quaternion StartRotation2 = cam.transform.rotation;

            Quaternion rotate2 = Quaternion.Euler(70f, 0f, 0f);

            cam.transform.rotation = Quaternion.Lerp(StartRotation2, rotate2, 0.2f);
            zoomtrue = false;
            return;
        }

      
        


    }

    void HandleTouch()
    {
        switch (Input.touchCount)
        {

            case 1: // Panning
                wasZoomingLastFrame = false;

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
                    PanCamera(Input.GetTouch(0).deltaPosition.x);
                }
                break;

            case 2: // Zooming
                Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
                if (!wasZoomingLastFrame)
                {
                    lastZoomPositions = newPositions;
                    wasZoomingLastFrame = true;
                }
                else
                {
                    // Zoom based on the distance between the new positions compared to the 
                    // distance between the previous positions.
                    float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                    float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                    float offset = newDistance - oldDistance;

                    ZoomCamera(offset, ZoomSpeedTouch);

                    lastZoomPositions = newPositions;
                }
                break;

            default:
                wasZoomingLastFrame = false;
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
            PanCamera(Input.GetAxis("Mouse X"));
        }

        // Check for scrolling to zoom the camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, ZoomSpeedMouse);
    }

    void PanCamera(float newPanPosition)
    {
        // Determine how much to move the camera
       // Vector3 offset = cam.ScreenToWorldPoint(lastPanPosition - newPanPosition);
       if (CurrentPosition == 2)
        {
            Vector3 move = new Vector3(0, newPanPosition * PanSpeed, 0);

            transform.Rotate(move, Space.World);
        }

       // lastPanPosition = newPanPosition;
    }

    private void zoomInorOut()
    {
        OldFOV = cam.fieldOfView;
    }

    void ZoomCamera(float offset, float speed)
    {
        zoomtrue = true;

        if (offset == 0)
        {
            return;
        }

        if (CurrentFOV >= 79.5f && CurrentPosition == 0)
        {
            zoomInorOut();

            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);

            if (cam.fieldOfView > OldFOV)
            {
                ZoomingIn = false;
                ZoomingOut = true;
            }
            else
            {
                ZoomingIn = true;
                ZoomingOut = false;
            }

        }

        if (CurrentFOV <= 37f && CurrentPosition == 1)
        {
            zoomInorOut();

            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);

            if (cam.fieldOfView > OldFOV)
            {
                ZoomingIn = false;
                ZoomingOut = true;
            }
            else
            {
                ZoomingIn = true;
                ZoomingOut = false;
            }
   
        }

        if (CurrentFOV >= 79.5f && CurrentPosition == 2)
        {

            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);

                ZoomingIn = false;
                ZoomingOut = true;

        }




    }


}





