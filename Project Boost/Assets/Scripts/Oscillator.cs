using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 m_startingPosition;
    [SerializeField] Vector3 m_movementVector;
    [SerializeField] [Range(0,1)] float m_movementFactor;
    [SerializeField] float period = 10f;

    // Start is called before the first frame update
    void Start()
    {
        m_startingPosition = transform.position;
        Debug.Log("Starting Position " + m_startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = 0;
        if (period <= Mathf.Epsilon)
            cycles = Time.time / period;  // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // from 1 to -1

        m_movementFactor = (rawSinWave + 1f) / 2f; // recalculated to from 0 to 1 so its cleaner

        Vector3 offset = m_movementVector * m_movementFactor;
        transform.position = m_startingPosition + offset;
    }
}
