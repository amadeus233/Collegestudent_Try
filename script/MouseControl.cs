using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
	private bool IsEnter=false;
	private bool isMouseDown = false;
	private Vector3 lastMousePosition = Vector3.zero;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isMouseDown = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDown = false;
			lastMousePosition = Vector3.zero;
		}
		if (isMouseDown&&IsEnter)
		{
			if (lastMousePosition != Vector3.zero)
			{
				Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
				this.transform.position += offset;
			}
			lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		}

	}
	private void OnMouseEnter()
	{
		IsEnter = true;
	}
	private void OnMouseExit()
	{
		IsEnter = false;
	}
    
}
