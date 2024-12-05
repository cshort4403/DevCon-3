using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CannonBallManager : MonoBehaviour
{

    [SerializeField]
    ParticleSystem SmokePartical;
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
            EnemyManager em;
            collision.gameObject.TryGetComponent(out em);
            em.TakeDamage();
            SmokePartical.transform.position = gameObject.transform.position;
            SmokePartical.Play();
            Destroy(gameObject);
		}
        if(collision.gameObject.CompareTag("Player"))
        {
            SmokePartical.transform.position = gameObject.transform.position;
            SmokePartical.Play();
            Destroy(gameObject);
        }
     
    }
}
