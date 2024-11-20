using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust ();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0,1,0 * mainThrust * Time.deltaTime);
            Debug.Log("SpaceBar was pressed");
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce (1,0,0);
            Debug.Log("A Right was pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("B Left was pressed");
        }
    }
}
