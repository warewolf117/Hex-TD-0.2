﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testing : MonoBehaviour
{
    

   private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DamagePopup2.Create(transform.position, 300);
        }
    }
}

   
