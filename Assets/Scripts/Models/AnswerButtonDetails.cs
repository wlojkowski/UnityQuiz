using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerButtonDetails
{
    Button button;
    Text buttonText;
    Image buttonBackground;
    Color defaultColor;
    Answer answer;
    public Answer Answer
    {
        get
        {
            return answer;
        }
        set
        {
            answer = value;
            buttonText.text = answer.AnswerContent;
        }
    }

    public AnswerButtonDetails(Text _answerText, Button _answerButton)
    {
        buttonText = _answerText;
        button = _answerButton;
        buttonBackground = button.GetComponent<Image>();
        defaultColor = buttonBackground.color;
    }

    public void ChangeBackgroundAccordingToAnswerCorrectness()
    {
        if (answer.IsCorrect)
        {
            SetBackgroundColorToGreen();
        }
        else
        {
            SetBackgroundColorToRed();
        }
    }

    public void SetBackgroundColorToRed()
    {
        buttonBackground.color = Color.red;
    }

    public void SetBackgroundColorToGreen()
    {
        buttonBackground.color = Color.green;
    }

    public void ResetButtonBackground()
    {
        buttonBackground.color = defaultColor;
    }

    public void SetAnswerButtonDetails(Answer _answer, UnityAction<Answer> action)
    {
        ResetButtonBackground();
        button.onClick.RemoveAllListeners();
        Answer = _answer;
        button.onClick.AddListener(() => action(Answer));
    }

}