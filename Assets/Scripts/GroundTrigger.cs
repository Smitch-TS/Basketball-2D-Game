using System.Collections;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] float timeToWait;
    bool bHasTriggered;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!bHasTriggered)
        {
            bHasTriggered = true;
            StartCoroutine(WaitAfterTrigger());
        }
    }

    private IEnumerator WaitAfterTrigger()
    {
        yield return new WaitForSeconds(timeToWait);

        // Reset the ball physics and advance the game phase
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdvanceGamePhase();
        bHasTriggered = false;
    }
}
