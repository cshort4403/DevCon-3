using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannon : MonoBehaviour
{
	
	[SerializeField]
	Transform CannonPivotPoint;

	
	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void RotateCannon(float RotSpeed)
	{
		CannonPivotPoint.Rotate(RotSpeed * Time.deltaTime, 0, 0);
		CannonPivotPoint.localEulerAngles = new Vector3(ClampAngle(CannonPivotPoint.localEulerAngles.x, -60, 0), 0, 0);
	}
	
	private float ClampAngle(float angle, float from, float to)
	{
		if (angle < 0f) angle = 360 + angle;
		if (angle > 180f) return Mathf.Max(angle, 360 + from);
		return Mathf.Min(angle, to);
	}

	
}
