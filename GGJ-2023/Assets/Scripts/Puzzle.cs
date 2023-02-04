using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string answerString;
    [SerializeField] PuzzlePart[] puzzleParts;

    public UnityEvent OnCorrectAnswer;

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i < puzzleParts.Length; i++)
        {
            puzzleParts[i].OnAnswerChanged += CheckAnswer;
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < puzzleParts.Length; i++)
        {
            puzzleParts[i].OnAnswerChanged -= CheckAnswer;
        }
    }

    private void CheckAnswer()
    {
        string output = "";

        for (int i = 0; i < puzzleParts.Length; i++)
        {
            output += puzzleParts[i].CurAnswer;
        }

        if (answerString.CompareTo(output) == 0)
        {
            OnCorrectAnswer?.Invoke();
        }
    }
    
}
