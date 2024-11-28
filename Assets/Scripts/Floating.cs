using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 2f;
    public float displacementAmount = 3f;
    public int floaterCount = 4;
    public float waterDrag = 0.01f;
    public float waterAngularDrag = 0.01f;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplyer = Mathf.Clamp01 ((waveHeight - transform.position.y  )/ depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplyer, 0f) , transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplyer * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplyer * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
