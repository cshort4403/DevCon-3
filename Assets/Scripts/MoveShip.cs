using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager)), RequireComponent(typeof(Rigidbody))]
public class MoveShip : MonoBehaviour
{

    public float MoveSpeed = 10.2778f; //37 km/h in m/s
    public float TurnSpeed = 60;

    Rigidbody rb;
    InputManager inputManager;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        if (inputManager.Forward)
        {
            rb.AddForce(rb.transform.forward * Time.deltaTime * MoveSpeed, ForceMode.Impulse);
        }

		if (inputManager.TurnLeft) 
        {
            transform.Rotate(0, -TurnSpeed * Time.deltaTime,0);
           
        }
        if(inputManager.TurnRight) 
        {
			transform.Rotate(0, TurnSpeed * Time.deltaTime,0);
		}

		if (inputManager.Stop)
		{
			rb.AddForce(-rb.transform.forward * Time.deltaTime * MoveSpeed, ForceMode.Impulse);
		}

	}
}
