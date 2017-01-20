using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMotion : MonoBehaviour
{
    //public Color c1 = Color.red;
    //public int lineLength = 20;
    public int rund;
    public int tiles;


    void Start()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.numCornerVertices = rund;
        lineRenderer.numPositions = tiles;
    }


    void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.numCornerVertices = rund;
        int i = 0;
        while (i < lineRenderer.numPositions)
        {
            Vector3 pos = new Vector3(-10 + i * 0.1F, Mathf.Sin(i + Time.time));
            lineRenderer.SetPosition(i, pos);
            i++;
        }
        i = 0;

    }

}
