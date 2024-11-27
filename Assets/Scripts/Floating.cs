using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 2f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplyer = Mathf.Clamp01 ((waveHeight - transform.position.y  )/ depthBeforeSubmerged) * displacementAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplyer, 0f) , ForceMode.Acceleration);
        }
    }
}
