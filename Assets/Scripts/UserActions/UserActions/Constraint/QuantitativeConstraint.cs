public class QuantitativeConstraint : ActionConstraint
{
    public enum ConstraintSign { higherThan, lowerThan}
    public ConstraintSign sign;
    private int _upperBound, _lowerBound;
    readonly int _value;
    /// <summary>
    /// Constructor for Value Between Upper and Lower Boundry
    /// </summary>
    /// <param name="upperBound"></param>
    /// <param name="lowerBound"></param>
    /// <param name="value"></param>
    public QuantitativeConstraint(int upperBound, int lowerBound,int value)
    {
        _value = value;
        _upperBound = upperBound;
        _lowerBound = lowerBound;
    }
    /// <summary>
    /// Constructor for single input with upper or lower value
    /// </summary>
    /// <param name="upperBound"></param>
    /// <param name="lowerBound"></param>
    /// <param name="value"></param>
    public QuantitativeConstraint(int Bound, int value, ConstraintSign constraintSign)
    {
        _value = value;
        switch (constraintSign)
        {
            case ConstraintSign.higherThan:
                _lowerBound = Bound;
                break;
            case ConstraintSign.lowerThan:
                _upperBound = Bound;
                break;
        }
    }
    public override void CheckConstraint(ResponseToConstraint response)
    {
        if (_value < _lowerBound)
            response.Invoke();
        else if (_value > _upperBound)
            response.Invoke();
        else if (_value < _upperBound)
            response = null;
    }

    public override bool CheckConstraint()
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckConstraint(out UserAction actionOfInterest)
    {
        throw new System.NotImplementedException();
    }
}
