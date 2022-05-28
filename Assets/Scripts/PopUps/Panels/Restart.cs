using TMPro;

public class Restart : PopUps
{

    public TextMeshProUGUI _ResetTextField;

    public void SetText(string text)
    {
        _ResetTextField.text = text;
    }

}
