using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    [Header("Object Bindings")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] answerButtons;

    [Header("Try Again Parameters")]
    [SerializeField] private string tryAgainMessage;
    [SerializeField] private float messageDisplayTime;

    [Header("Variables for testing")]
    //Exposed currently for demo - would make this data driven / random in the future
    [SerializeField] private String[] potentialAnswers;
    [SerializeField] private int correctAnswerIdx;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        int lastIdx =0;

        //
        for (int curIdx = 0; curIdx < potentialAnswers.Length; ++curIdx)
        {
            if (curIdx < answerButtons.Length)
            {
                // Set button to active and update the text on the button
                answerButtons[curIdx].gameObject.SetActive(true);
                answerButtons[curIdx].GetComponentInChildren<TMP_Text>().text = potentialAnswers[curIdx];
                answerButtons[curIdx].onClick.RemoveAllListeners();

                // Bind button based on if its the right answer or not
                if (curIdx == correctAnswerIdx)
                {
                    answerButtons[curIdx].onClick.AddListener(CorrectAnswer);
                }
                else
                {
                    answerButtons[curIdx].onClick.AddListener(WrongAnswer);
                }

                lastIdx = curIdx;
            }
        }

        // Loop through remaining buttons and hide them
        for (int curIdx = lastIdx+1; curIdx < answerButtons.Length; ++curIdx)
        {
            answerButtons[curIdx].onClick.RemoveAllListeners();
            answerButtons[curIdx]?.gameObject.SetActive(false);
        }
    }

    private void CorrectAnswer()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdvanceGamePhase();
    }

    private void WrongAnswer()
    {
        StartCoroutine(TryAgainMessage());
    }

    private IEnumerator TryAgainMessage()
    {
        string curQuestion = questionText.text;
        questionText.text = tryAgainMessage;
        yield return new WaitForSeconds(messageDisplayTime);
        questionText.text = curQuestion;
    }
}
