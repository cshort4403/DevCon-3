using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MoveEnemyShip : MonoBehaviour
{
    GameObject Target;

    [SerializeField]
    float MoveSpeed = 10.2778f;
    [SerializeField]
    float TurnSpeed = 10.2778f;

    Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}


	// Start is called before the first frame update
	void Start()
    {
        Target = GameObject.Find("PlayerShip");
        if(Target == null)
        {
            Debug.LogError("Enemy cannot find the player ship!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
	}

    void RotateToFaceTarget()
    {
        transform.LookAt(Target.transform, Vector3.up);
	}

    void Move()
    {
        RotateToFaceTarget();
		rb.AddForce(rb.transform.forward * Time.deltaTime * MoveSpeed * 500, ForceMode.Impulse); 
        
	}

   
    


}
