using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    Renderer rend;
    static readonly int materialColor = Shader.PropertyToID("_EmissionColor");

    void Start()
    {
        rend = GetComponent<Renderer>();  
    }


    void Update()
    {
        Health healthScript = transform.gameObject.GetComponent<Health>();

        if (healthScript.cur_health < 400 && healthScript.cur_health > 300)
            rend.material.SetColor(materialColor, new Color(0.3189f, 3.245283f, 0, 2));//r,g,b,intensity

       if (healthScript.cur_health < 300 && healthScript.cur_health > 200)
            rend.material.SetColor(materialColor, new Color(3.0321f, 3.245283f, 0, 2));

        if (healthScript.cur_health < 200 && healthScript.cur_health > 100)
            rend.material.SetColor(materialColor, new Color(4.332708f, 1.249614f, 0, 2));

        if (healthScript.cur_health < 100)
            rend.material.SetColor(materialColor, new Color(2.216312f, 0.0090094f, 0, 1.565086f));


    }
}
