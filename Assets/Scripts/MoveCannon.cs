using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class MoveCannon : MonoBehaviour
{
	
	[SerializeField]
	GameObject CannonPivotPoint;

	[SerializeField]
	float CannonRotSpeed = 60f;

	InputManager inputManager;

	private void Awake()
	{
		inputManager = GetComponent<InputManager>();
	}
	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.AngleUp)
		{
			RotateCannon(-CannonRotSpeed);
		}
		if(inputManager.AngleDown) 
		{
			RotateCannon(CannonRotSpeed);
		}
    }

	private void RotateCannon(float RotSpeed)
	{
		CannonPivotPoint.transform.Rotate(RotSpeed * Time.deltaTime, 0, 0);

		if(CannonPivotPoint.transform.rotation.eulerAngles.x > 80 || CannonPivotPoint.transform.rotation.eulerAngles.x < 30)
		{
			CannonPivotPoint.transform.Rotate(-RotSpeed * Time.deltaTime, 0, 0);
		}

	}

	
}
