using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionPanelModel : MonoBehaviour {
    public Text QuestionText;

    public Button[] AnswerButtonsList;

    public AnswerEvent AnswerSelected;

    List<AnswerButtonDetails> answerButtonDetailsList;

    private void Awake()
    {
        AnswerSelected = new AnswerEvent();
        answerButtonDetailsList = new List<AnswerButtonDetails>();
        foreach(Button button in AnswerButtonsList)
        {
            answerButtonDetailsList.Add(new AnswerButtonDetails(button.GetComponentInChildren<Text>(), button));
        }
    }

    public void AnswerClicked(Answer answer)
    {
        if(AnswerSelected != null)
        {
            AnswerSelected.Invoke(answer);
        }
        foreach (AnswerButtonDetails answerDetails in answerButtonDetailsList)
        {
            answerDetails.ChangeBackgroundAccordingToAnswerCorrectness();
        }
    }

    public void ShowNewQuestion(Question question)
    {
        QuestionText.text = question.QuestionText;
        int index = 0;
        if(question.AnswerList.Count > AnswerButtonsList.Length)
        {
            Debug.LogError("Number of answers does not match with number of avaible buttons");
            throw new System.ArgumentOutOfRangeException();
        }
        foreach(Answer answer in question.AnswerList)
        {
            answerButtonDetailsList[index].SetAnswerButtonDetails(answer, AnswerClicked);
            index++;
        }
    }
}

[System.Serializable]
public class AnswerEvent : UnityEvent<Answer>
{
}