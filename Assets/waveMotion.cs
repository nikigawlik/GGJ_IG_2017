using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class waveMotion : MonoBehaviour
{
    public float amplitude = 1;
    public float speed;
    public float pointDistance;
	private float speedhub = 0;

	float screenWidth;
	public Camera cam;
	private WavePointGenerator wavePointGen;


    void Start()
    {
		wavePointGen = GetComponent<WavePointGenerator> ();
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		lineRenderer.numPositions = wavePointGen.maxPoints;

		screenWidth = 2f * cam.orthographicSize * cam.aspect;
		pointDistance = screenWidth / lineRenderer.numPositions;
    }


    void FixedUpdate()
    {
        speedhub = speedhub + speed;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        int i = 0;
        float currentTime = Time.time + speedhub;

		while (i < lineRenderer.numPositions)
        {
			Vector3 pos = new Vector3(-screenWidth/2 + i*pointDistance, wavePointGen.pointList.ElementAt(i), 0);
            lineRenderer.SetPosition(i, pos);

            i++;
        }
		//Debug.Log (i);
        

	}


	public float GetYAt(float x) {
		float screenX = Math.Min (Math.Max (x + screenWidth/2, 0), screenWidth);
		int index1 = (int)Math.Floor (screenX / pointDistance);
		//float index2 = Math.Ceil (screenWidth / wavePointGen.maxPoints);
		//float delta = x - index1; TODO interpol

		index1 = Math.Min (Math.Max (index1, 0), wavePointGen.maxPoints - 1);

		return wavePointGen.pointList.ElementAt(index1);
	}


	public float GetSlopeAt(float x) {
		float screenX = Math.Min (Math.Max (x + screenWidth/2, 0), screenWidth);
		int index1 = (int)Math.Floor (screenX / pointDistance) - 1;
		int index2 = index1 + 2;
		//float index2 = Math.Ceil (screenWidth / wavePointGen.maxPoints);
		//float delta = x - index1; TODO interpol

		index1 = Math.Min (Math.Max (index1, 0), wavePointGen.maxPoints - 1);
		index2 = Math.Min (Math.Max (index2, 0), wavePointGen.maxPoints - 1);

		return (wavePointGen.pointList.ElementAt(index2) - wavePointGen.pointList.ElementAt(index1)) / pointDistance;
	}

}
