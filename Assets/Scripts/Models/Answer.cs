using System;

[Serializable]
public class Answer
{
    public int Id { get; set; }
    public string AnswerContent { get; set; }
    public bool IsCorrect { get; set; }
}
