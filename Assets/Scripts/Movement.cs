using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100000f;
    [SerializeField] float rotationThrust = 50.0f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;


    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust ();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }
    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Play();
        }
    }
    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!rightThrustParticles.isPlaying)
        {
            rightThrustParticles.Play();
        }
    }
    void StopRotating()
    {
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
