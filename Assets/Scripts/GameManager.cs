using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // enum for keeping track of GamePhases
    enum GamePhase
    {
        Tutorial,
        Question,
        Playing
    }

    [Header("UI Object References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private GameObject questionWindow;
    [SerializeField] private GameObject shotControls;
    
    [Header("CharacterMovement")]
    [SerializeField] private GameObject[] objectsToMove;
    [SerializeField] private float movementRange;


    // Script internal tracking variables
    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;
    private GamePhase currentPhase;
    private int CurrentScore;

    private void Start()
    {
        // Set the starting phase and trigger updates
        currentPhase = GamePhase.Tutorial;
        OnPhaseUpdated();

        // Store positions of objects for reference later
        Array.Resize(ref originalPositions, objectsToMove.Length);
        Array.Resize(ref originalRotations, objectsToMove.Length);
        for (int curIdx = 0; curIdx < originalPositions.Length; ++curIdx)
        {
            originalPositions[curIdx] = objectsToMove[curIdx].transform.position;
            originalRotations[curIdx] = objectsToMove[curIdx].transform.rotation;
        }
    }

    public void AdvanceGamePhase()
    {
        // Tutorial should only be reached on start so Playing should cycle back to Question
        if(currentPhase == GamePhase.Playing)
        {
            currentPhase = GamePhase.Question;
        }
        else
        {
            ++currentPhase;
        }
        OnPhaseUpdated();
    }

    public void IncrementScore()
    {
        ++CurrentScore;
        scoreText.SetText(CurrentScore.ToString());
    }

    private void OnPhaseUpdated()
    {
        // Switch to trigger different behaviour based on current game phase
        switch (currentPhase)
        {
            case GamePhase.Tutorial:
                tutorialWindow.SetActive(true);
                questionWindow.SetActive(false);
                shotControls.SetActive(false);
                break;
            case GamePhase.Question:
                tutorialWindow.SetActive(false);
                questionWindow.SetActive(true);
                shotControls.SetActive(false);
                break;
            case GamePhase.Playing:
                MoveCharacters();
                tutorialWindow.SetActive(false);
                questionWindow.SetActive(false);
                shotControls.SetActive(true);
                break;
        }
    }

    private void MoveCharacters()
    {
        // Reset the basketball
        BallBehaviour ball = FindAnyObjectByType<BallBehaviour>();
        ball?.ResetObject();

        float translationAmount = UnityEngine.Random.Range(-movementRange, movementRange);
        for(int curIdx = 0; curIdx < objectsToMove.Length; ++curIdx)
        {
            objectsToMove[curIdx].transform.position = originalPositions[curIdx] + new Vector3(translationAmount, 0.0f, 0.0f);
            objectsToMove[curIdx].transform.rotation = originalRotations[curIdx];
        }
    }
}
