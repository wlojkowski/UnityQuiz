using System;
using System.Collections.Generic;

[Serializable]
public class Question {

    public int Id;
    public string QuestionText;
    public List<Answer> AnswerList;

}
