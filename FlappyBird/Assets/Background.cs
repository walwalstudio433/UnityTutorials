using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour 
{	
	public SpriteRenderer left, right;
	public Sprite spriteDay;
	public Sprite spriteNight;
	public GameObject pillarLeft, pillarRight;
	public float speed, cut;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Translate (Vector3.left * Time.deltaTime * speed);
		if (left.transform.position.x < cut) 
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
		SpriteRenderer temp = left;
		left = right;
		right = temp;
		right.transform.localPosition = left.transform.localPosition + new Vector3(1.38f, 0, 0);
		left.sortingOrder = 0;
		right.sortingOrder = 1;
	}

	void returnPillar ()
	{
		GameObject temp = pillarLeft;
		pillarLeft = pillarRight;
		pillarRight = temp;
		pillarRight.transform.localPosition = pillarLeft.transform.localPosition + new Vector3 (1.5f, 0, 0);
		Vector3 newV = pillarRight.transform.localPosition;
		newV.y = Random.Range (-0.5f, 0.5f);
		pillarRight.transform.localPosition = newV;
	}
}
