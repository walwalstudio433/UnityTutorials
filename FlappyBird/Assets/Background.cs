using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour 
{	
	public GameObject movingRoot;
	public GameObject floorLeft, floorRight;
	public GameObject pillarLeft, pillarRight;
	public float speed, cut;
	public float floorInterval, pillarInterval;
	public bool stopped;

	void Update () 
	{
		if (stopped)
			return;
		movingRoot.transform.Translate (Vector3.left * Time.deltaTime * speed);
		if (floorLeft.transform.position.x < cut) 
		{
			returnBackground ();
		}
		if (pillarLeft.transform.position.x < cut) 
		{
			returnPillar ();
		}
	}

	void returnBackground()
	{
		GameObject temp = floorLeft;
		floorLeft = floorRight;
		floorRight = temp;
		floorRight.transform.localPosition = floorLeft.transform.localPosition + new Vector3(floorInterval, 0, 0);
		//floorLeft.sortingOrder = 0;
		//floorRight.sortingOrder = 1;
	}

	void returnPillar ()
	{
		GameObject temp = pillarLeft;
		pillarLeft = pillarRight;
		pillarRight = temp;
		pillarRight.transform.localPosition = pillarLeft.transform.localPosition + new Vector3 (pillarInterval, 0, 0);
		Vector3 newV = pillarRight.transform.localPosition;
		newV.y = Random.Range (-0.5f, 0.5f);
		pillarRight.transform.localPosition = newV;
	}

	public void Stop()
	{
		stopped = true;
	}
}
