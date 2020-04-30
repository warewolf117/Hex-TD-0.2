using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveStarter : MonoBehaviour
{
    public GameObject waveStarter;
    public UnityEvent OnClick = new UnityEvent();

     


    void Start()
    {
        waveStarter = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveStarter == enabled)
        {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Debug.Log("Button Clicked");
                WaveSpawner.startFirstWave++;
                OnClick.Invoke();

                    GameObject[] objects = GameObject.FindGameObjectsWithTag("WaveIndicator");
                
                    for (int i=0; i<objects.Length; i++)
                    {
                      Destroy(objects[i]);
                    }
                
            }
        }
        }

    }
}
