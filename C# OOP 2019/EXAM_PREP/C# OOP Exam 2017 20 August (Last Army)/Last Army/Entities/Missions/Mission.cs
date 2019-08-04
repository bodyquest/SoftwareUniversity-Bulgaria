using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        ScoreToComplete = scoreToComplete;
    }

    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public abstract double WearLevelDecrement { get; }
}
