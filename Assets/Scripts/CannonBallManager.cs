using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CannonBallManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.gameObject);
		}

	}
}