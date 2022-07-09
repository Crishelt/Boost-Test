using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float PropellerForce = 20f;
    [SerializeField] float RotationForce = 5f;
    private Rigidbody rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
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
            rocket.AddRelativeForce(Vector3.up * PropellerForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
    }

    void ApplyRotation(Vector3 direction)
    {
        rocket.AddRelativeTorque(direction * RotationForce * Time.deltaTime, ForceMode.Impulse);
    }
}
