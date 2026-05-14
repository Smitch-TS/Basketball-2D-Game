using UnityEngine;

public class HoopBehaviour : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Only one gamemanager should exist in a scene
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.IncrementScore();
    }
}
