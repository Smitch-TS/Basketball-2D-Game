using UnityEngine;

public class HoopBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;

    private void Start()
    {
        // Only one gamemanager should exist in a scene
        gameManager = FindAnyObjectByType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.PlayOneShot(audioSource.clip);
        gameManager.IncrementScore();
    }
}
