using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFPC_WaterMover : MonoBehaviour {

	public float speedX = 0.2f, speedY = 0.1f; // The x and y movement speed of x and y offset respectively

	private float currentX, currentY; // The current x and y movement speed of the x and y offset respectively

	private Renderer rend;
	void Awake () 
	{
		rend = GetComponent<Renderer> ();
		currentX = rend.material.mainTextureOffset.x;
		currentY = rend.material.mainTextureOffset.y;
	}

	void FixedUpdate ()
	{
		currentX += Time.deltaTime * speedX;
		currentY += Time.deltaTime * speedY;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (currentX, currentY));
	}
}
