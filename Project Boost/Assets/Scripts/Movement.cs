using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    [SerializeField]
    public float     m_thurstForce = 1000f;
    [SerializeField]
    public float     m_rotationForce = 100f;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
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
            Debug.Log("In space code block implementation!");
            m_rigidbody.AddRelativeForce(Vector3.up *  m_thurstForce * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key pressed");
            RotateByDirection(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key pressed");
            RotateByDirection(Vector3.back);
        }
    }

    private void RotateByDirection(Vector3 direction)
    {
        m_rigidbody.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(direction * m_rotationForce * Time.deltaTime);
        m_rigidbody.freezeRotation = false;
    }

}
