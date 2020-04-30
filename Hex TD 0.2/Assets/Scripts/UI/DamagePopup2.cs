﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup2: MonoBehaviour
{
    

    public static DamagePopup2 Create(Vector3 position, float damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup2 damagePopup = damagePopupTransform.GetComponent<DamagePopup2>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    public static DamagePopup2 CreateLaser(Vector3 position, float damageAmount)
    {

             float f = damageAmount;
             f = Mathf.Round(f * 1.0f) * 1f;
             Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position + Vector3.up * 2 , Quaternion.identity);
             DamagePopup2 damagePopupL = damagePopupTransform.GetComponent<DamagePopup2>();
            
            
            damagePopupL.SetupL(f);
            return damagePopupL;  
        

    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 0.2f;
  

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void SetupL(float damageAmount)
    {
        Color Lasercolor = Color.magenta;
        textMesh.SetText(damageAmount.ToString());
        textMesh.color = Lasercolor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(-0.7f, 1) * 10f;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }

    public void Setup(float damageAmount)
    {
       
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(.7f,1) * 15f;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }

    private void Update()
    {
        
        transform.position += (moveVector * Time.deltaTime);
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f) //first half of the popup lifetime
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else //second half of the popup lifetime
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 2f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a <0)
            {
                Destroy(gameObject);
            }
        }
    }
}