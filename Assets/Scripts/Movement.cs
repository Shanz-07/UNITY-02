using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationspeed = 500f;
    [SerializeField] ParticleSystem mainthrustParticles;
    [SerializeField] ParticleSystem RightThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
           mainthrustParticles.Play();
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward*Time.deltaTime*rotationspeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward*Time.deltaTime*rotationspeed);
        }
    }
}
