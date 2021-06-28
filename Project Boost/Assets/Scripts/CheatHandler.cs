using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatHandler : MonoBehaviour
{
    private Collider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            m_collider.enabled = false;
        }
    }
}
