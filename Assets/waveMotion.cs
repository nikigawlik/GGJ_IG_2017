using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMotion : MonoBehaviour
{
    public int tiles;
    public float amplitude = 1;
    public float speed;
    public float frequenz = 1F;

    private float speedhub = 0;


    void Start()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.numPositions = tiles;
    }


    void Update()
    {
        speedhub = speedhub + speed;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        int i = 0;
        float currentTime = Time.time + speedhub;
        while (i < lineRenderer.numPositions)
        {
            Vector3 pos = new Vector3(-10 + i*frequenz, (Mathf.Sin(i + currentTime))*amplitude);
            lineRenderer.SetPosition(i, pos);
            i++;
        }
        i = 0;

    }

}
