using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    AudioClip m_onObstacleCollisionClip;
    [SerializeField]
    AudioClip m_onFinishClip;
    [SerializeField]
    float m_levelLoadDelay = 1f;

    [SerializeField] ParticleSystem m_successParticles;
    [SerializeField] ParticleSystem m_crashParticles;


    AudioSource m_audioSource;

    bool m_isTransitioning = false;

    void Start() 
    {
         m_audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (!m_isTransitioning)
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Collision with friendly object");
                    break;
                case "Fuel":
                    Debug.Log("Fuel up");
                    break;
                case "Obstacle":
                    Debug.Log("Collision with obstacle. Your rocket get hit!");
                    StartCrashSequence();
                    break;
                case "Finish":
                    Debug.Log("FINISH!");
                    StartSuccessSequence();
                    break;
                default:
                    Debug.Log("Collision with underfined object!");
                    StartCrashSequence();
                    break;
            }
        }
    }

    private void StartSuccessSequence()
    {
        m_isTransitioning = true;
        m_audioSource.Stop();
        m_audioSource.PlayOneShot(m_onFinishClip);
        m_successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", m_levelLoadDelay);

        if (m_audioSource.isPlaying)
            m_audioSource.Stop();
    }

    private void StartCrashSequence()
    {
        m_isTransitioning = true;
        m_audioSource.Stop();
        m_audioSource.PlayOneShot(m_onObstacleCollisionClip);
        m_crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", m_levelLoadDelay);
    }
    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //if (nextSceneIndex < SceneManager.sceneCount)
            SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
