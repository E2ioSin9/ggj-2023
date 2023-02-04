using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePart : Interactable
{
    [SerializeField] private string[] answerList;
    [SerializeField] private int curAnswerListIndex = 0;
    [SerializeField] private string curAnswer;
    public string CurAnswer => curAnswer;

    [SerializeField] private TextMeshPro ansText;

    public Action OnAnswerChanged;
    public UnityEvent OnAnswerChangedUnityEvent;

    private void Start()
    {
        curAnswerListIndex = 0;
        SetAnswer(curAnswerListIndex);
    }

    private void SetAnswer(int index)
    {
        curAnswer = answerList[curAnswerListIndex];
        ansText.text = curAnswer;
    }

    public override void Interact()
    {
        curAnswerListIndex = (curAnswerListIndex + 1) % answerList.Length;

        SetAnswer(curAnswerListIndex);
        OnAnswerChanged?.Invoke();
        OnAnswerChangedUnityEvent?.Invoke();
    }

    public override void ShowHighlight()
    {
        //renderer.material = highlightMaterial;
    }

    public override void HideHighlight()
    {
        //renderer.material = defaultMaterial;
    }
}
