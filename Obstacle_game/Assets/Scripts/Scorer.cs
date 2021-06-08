using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public  int m_bumpCounter = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag != "Hit")
        {
            m_bumpCounter++;
            Debug.Log("Bumped into a wall " + m_bumpCounter + " times!");
        }
    }
}
