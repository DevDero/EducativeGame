using TMPro;

public class QuizLabel : ActionLabel
{
    TextMeshProUGUI _time;
    public QuizLabel(string repetition, string score, int time) : base(repetition, score)
    {
        _time.text = time.ToString();
    }
}