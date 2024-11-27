using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100000f;
    [SerializeField] float rotationThrust = 50.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem mainEngineParticles;

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
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftThrustParticles.Play();
            ApplyRotation(rotationThrust);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightThrustParticles.Play();
            ApplyRotation(-rotationThrust);
        }
        else
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
