using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;

    [SerializeField, Tooltip("Amount of Newtons of force.")]
    float fireForce= 17300;

    [SerializeField]
    Transform ExplosionPoint;

    Rigidbody BallRB;
    

    // Start is called before the first frame update
    void Start()
    {
        //Check to make sure only the cannons can fire cannon balls.
        if(!CompareTag("TopCannon") && !CompareTag("BottomCannon"))
        {
            Debug.LogError($"Script FireBall is attached to something other than a cannon! It has the tag: {tag}");
        }

        if(!Ball.TryGetComponent(out BallRB)) 
        {
            Debug.LogError("The FireBall script does not have a ball with a rigidbody to fire. Please make sure the cannon is firing something with a rigidbody component.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Create a new cannon ball and shoot it out of the cannon.
    /// </summary>
    public void Fire()
    {
        Ball.transform.SetPositionAndRotation(ExplosionPoint.position + Vector3.right, ExplosionPoint.rotation);
		Instantiate(Ball);
        BallRB.AddExplosionForce(fireForce, ExplosionPoint.position, 10, 1000);
    }

}
