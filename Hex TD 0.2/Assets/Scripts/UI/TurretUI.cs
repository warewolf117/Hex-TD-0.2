using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretUI : MonoBehaviour
{
    public GameObject UIbutton;
    public UnityEvent OnClick = new UnityEvent();

    void Start()
    {
        
       UIbutton = this.gameObject;
    }

    void Update()
    {

        if (UIbutton == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    OnClick.Invoke();

                }
            }
        }
    }
}

