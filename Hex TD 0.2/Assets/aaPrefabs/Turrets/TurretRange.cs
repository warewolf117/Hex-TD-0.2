﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class TurretRange : MonoBehaviour
{

    [Range(0.1f, 100f)]
    public float radius = 1.0f;

    [Range(3, 256)]
    public int numSegments = 128;

    [System.Obsolete]
    void Start()
    {
        DoRenderer();
    }

    [System.Obsolete]
    public void DoRenderer()
    {
        radius = Turret.rangeRender;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(0.5f, 0.5f, 0.5f, 1);
        lineRenderer.SetColors(c1, c1);
        lineRenderer.SetWidth(0.5f, 0.5f);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}