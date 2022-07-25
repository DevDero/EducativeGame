public class QuantitativeConstraint : ActionConstraint
{
    public enum ConstraintSign { between, higherThan, lowerThan}
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
        sign = ConstraintSign.between;
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
                _upperBound = Bound;
                break;
            case ConstraintSign.lowerThan:
                _lowerBound = Bound;
                break;
        }
    }
    public override void CheckConstraint(bool outComePositive , ResponseToConstraint response)
    {
        if (!outComePositive)
        {
            if (sign == ConstraintSign.between)
            {
                if (_value < _lowerBound)
                    response.Invoke();
                else if (_value > _upperBound)
                    response.Invoke();
                else if (_value < _upperBound)
                    response = null;
            }
            else if (sign == ConstraintSign.lowerThan)
            {
                if (_value > _upperBound)
                    response.Invoke();
                else
                    response = null;
            }
            else if (sign == ConstraintSign.higherThan)
            {
                if (_value < _lowerBound)
                    response.Invoke();
                else
                    response = null;
            }
        }
        else
        {
            if (sign == ConstraintSign.between)
            {
                if (_value < _lowerBound)
                    response = null;
                else if (_value > _upperBound)
                    response = null;
                else if (_value < _upperBound)
                    response.Invoke();

            }
            else if (sign == ConstraintSign.lowerThan)
            {
                if (_value > _upperBound)
                    response = null;
                else 
                    response.Invoke();

            }
            else if (sign == ConstraintSign.higherThan)
            {
                if (_value < _lowerBound) 
                    response = null;
                else 
                    response.Invoke();
            }
        }

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
