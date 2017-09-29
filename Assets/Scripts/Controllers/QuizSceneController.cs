using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSceneController : MonoBehaviour {

    QuizController quizController;
    public QuestionPanelModel QuestionPanelModel;

    void Start()
    {

        Question testQuestion1 = new Question()
        {
            Id = 0,
            QuestionText = "Ile to jest 2+2",
            AnswerList = new List<Answer>()
            {
                new Answer() { Id = 0, AnswerContent = "4", IsCorrect = true },
                new Answer() { Id = 1, AnswerContent = "33", IsCorrect = false },
                new Answer() { Id = 2, AnswerContent = "2", IsCorrect = false },
                new Answer() { Id = 3, AnswerContent = "9", IsCorrect = false }
            }
        };
        Question testQuestion2 = new Question()
        {
            Id = 1,
            QuestionText = "Które miasto jest stolicą Holandii",
            AnswerList = new List<Answer>()
            {
                new Answer() { Id = 0, AnswerContent = "Berlin", IsCorrect = false },
                new Answer() { Id = 1, AnswerContent = "Waszyngton", IsCorrect = false },
                new Answer() { Id = 2, AnswerContent = "Amsterdam", IsCorrect = true },
                new Answer() { Id = 3, AnswerContent = "Bruksela", IsCorrect = false }
            }
        };
        List<Question> testQuestionList = new List<Question>();
        testQuestionList.Add(testQuestion1);
        testQuestionList.Add(testQuestion2);

        quizController = new QuizController(testQuestionList);
        QuestionPanelModel.AnswerSelected.AddListener(QuestionAnswered);

        if (quizController == null)
        {
            Debug.LogError("Quiz controller is equal to null");
            throw new System.NullReferenceException();
        }
        if (QuestionPanelModel == null)
        {
            Debug.LogError("QuestionPanelDetails is equal to null");
            throw new System.NullReferenceException();
        }
        quizController.NextRandomQuestion();
        QuestionPanelModel.ShowNewQuestion(quizController.GetActiveQuestion());


    }
    public void QuestionAnswered(Answer chosenAnswer)
    {
        quizController.CheckSelectedAnswer(chosenAnswer);
        StartCoroutine(PrepareNextQuestion());
    }

    IEnumerator PrepareNextQuestion()
    {
        yield return new WaitForSeconds(3f);
        quizController.NextRandomQuestion();
        QuestionPanelModel.ShowNewQuestion(quizController.GetActiveQuestion());
    }

}
