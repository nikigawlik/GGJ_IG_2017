using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

}
