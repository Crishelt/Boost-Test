using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float propellerForce = 20f;
    [SerializeField] float rotationForce = 5f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] List<ParticleSystem> propellerParticles;
    Rigidbody rocket;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            rocket.AddRelativeForce(Vector3.up * propellerForce * Time.deltaTime, ForceMode.Impulse);
            if (!audioSource.isPlaying)
            {
                propellerParticles.ForEach(x => x.Play());
                audioSource.PlayOneShot(engineSound);
            }
        }
        else
        {
            audioSource.Stop();
            propellerParticles.ForEach(x => x.Stop());
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
        rocket.AddRelativeTorque(direction * rotationForce * Time.deltaTime, ForceMode.Impulse);
    }
}
