using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning? typically set in the editor
    [SerializeField]
    public float     m_thurstForce = 1000f;
    [SerializeField]
    public float     m_rotationForce = 100f;
    [SerializeField]
    public AudioClip m_mainEngine;
    // CACHE - e.g. references for readability or speed
    [SerializeField] ParticleSystem m_mainThurstParticles;
    [SerializeField] ParticleSystem m_leftThurstParticles;
    [SerializeField] ParticleSystem m_rightThurstParticles;

    private Rigidbody   m_rigidbody;
    private AudioSource m_audioSource;

    // STATE - private instance (member) variables
    bool m_isAlive;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
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
            if (!m_audioSource.isPlaying)
                m_audioSource.PlayOneShot(m_mainEngine);
            m_rigidbody.AddRelativeForce(Vector3.up *  m_thurstForce * Time.deltaTime);
            m_mainThurstParticles.Play();
        }
        else
        {
            m_audioSource.Stop();
            m_mainThurstParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key pressed");
            RotateByDirection(Vector3.forward);
            m_leftThurstParticles.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key pressed");
            RotateByDirection(Vector3.back);
            m_rightThurstParticles.Play();
        }
        else
        {
            m_rightThurstParticles.Stop();
            m_leftThurstParticles.Stop();
        }
    }

    private void RotateByDirection(Vector3 direction)
    {
        m_rigidbody.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(direction * m_rotationForce * Time.deltaTime);
        m_rigidbody.freezeRotation = false;
    }

}
