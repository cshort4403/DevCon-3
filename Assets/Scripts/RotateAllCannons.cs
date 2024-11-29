using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class RotateAllCannons : MonoBehaviour
{

	[SerializeField]
	float CannonRotSpeed = 60f;

	InputManager M_Input;
	GameObject[] TopCannons;
	GameObject[] BottomCannons;
	// Start is called before the first frame update
	private void Awake()
	{
		M_Input = GetComponent<InputManager>();
	}
	// Start is called before the first frame update
	void Start()
	{
		TopCannons = GameObject.FindGameObjectsWithTag("TopCannon");
		BottomCannons = GameObject.FindGameObjectsWithTag("BottomCannon");
	}

	// Update is called once per frame
	void Update()
    {
		if (M_Input.AngleUp)
		{
			foreach (GameObject g in BottomCannons)
			{
				CannonRotate(g, -CannonRotSpeed);
			}
			foreach (GameObject g in TopCannons)
			{
				CannonRotate(g, -CannonRotSpeed);
			}

		}
		if (M_Input.AngleDown)
		{
			foreach (GameObject g in BottomCannons)
			{
				CannonRotate(g, CannonRotSpeed);
			}
			foreach (GameObject g in TopCannons)
			{
				CannonRotate(g, CannonRotSpeed);
			}

		}
	}

	void CannonRotate(GameObject g, float rotSpeed)
	{
		g.GetComponent<MoveCannon>().RotateCannon(rotSpeed);
	}


}
