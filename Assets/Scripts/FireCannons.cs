using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotState
{ 
    IDLE = 0,
    SHOT1 = 1,
    SHOT2 = 2
}


[RequireComponent(typeof(InputManager))]
public class FireCannons : MonoBehaviour
{

    [SerializeField]
    float ShotCooldown = 2.0f;

    InputManager M_Input;

    GameObject[] TopCannons;
    GameObject[] BottomCannons;

    float ElapsedTime = 0;

    ShotState ShootingState;

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
        switch (ShootingState)
        {
            case ShotState.IDLE:
                if(M_Input.Shoot)
                {
                    Shoot1();
                    ShootingState = ShotState.SHOT1;
                    ElapsedTime = 0;
                }
                break;
            case ShotState.SHOT1:
                if(ElapsedTime > ShotCooldown / 2)
                {
                    Shoot2();
                    ShootingState = ShotState.SHOT2;
                }
                else
                {
                    ElapsedTime += Time.deltaTime;
                }
                break;
            case ShotState.SHOT2:
				if (ElapsedTime > ShotCooldown)
				{
					ShootingState = ShotState.IDLE;
				}
				else
				{
					ElapsedTime += Time.deltaTime;
				}
				break;
            default:
                break;
        }
    }

	private void Shoot1()
    {
        foreach(GameObject g in TopCannons) 
        {
            g.GetComponent<FireBall>().Fire();
        }
    }
    private void Shoot2()
	{
		foreach (GameObject g in BottomCannons)
		{
			g.GetComponent<FireBall>().Fire();
		}
	}
}
