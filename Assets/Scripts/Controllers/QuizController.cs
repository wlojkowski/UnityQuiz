using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizController {

    List<Question> questions;
    List<Question> answeredQuestions;

    Question activeQuestion;
    int score;

    public void IncreaseScore()
    {
        score++;
    }

    public QuizController(IEnumerable<Question> _questions)
    {
        LoadQuestions(_questions);
    }

    void LoadQuestions(IEnumerable<Question> _questions)
    {
        questions = new List<Question>(_questions);
        answeredQuestions = new List<Question>();
    }

    public Question GetActiveQuestion()
    {
        return activeQuestion;
    }

    public List<Answer> GetActiveAnswers()
    {
        return activeQuestion.AnswerList;
    }

    public void CheckSelectedAnswer(Answer _chosenAnswer)
    {
        if (_chosenAnswer.IsCorrect)
        {
            IncreaseScore();
        }
    }

    public void NextRandomQuestion()
    {
        Debug.Log(questions.Count);
        int index = Random.Range(0, questions.Count);
        Question questionToReturn = questions[index];
        questions.RemoveAt(index);
        activeQuestion = questionToReturn;
    }

}
