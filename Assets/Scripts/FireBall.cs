using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;

    [SerializeField, Tooltip("Amount of Newtons of force.")]
    float fireForce= 17300;

    // Start is called before the first frame update
    void Start()
    {
        //Check to make sure only the cannons can fire cannon balls.
        if(!CompareTag("TopCannon") && !CompareTag("BottomCannon"))
        {
            Debug.LogError($"Script FireBall is attached to something other than a cannon! It has the tag: {tag}");
        }

        if(!Ball.TryGetComponent<Rigidbody>(out _)) 
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
        GameObject newBall = Instantiate(Ball);
        newBall.transform.SetPositionAndRotation(transform.position, transform.rotation);
		newBall.transform.position += newBall.transform.forward;
		newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * fireForce * Time.deltaTime, ForceMode.Impulse);
        Debug.Log($"Fired cannon with force {newBall.transform.forward * fireForce * Time.deltaTime}");
    }

}
