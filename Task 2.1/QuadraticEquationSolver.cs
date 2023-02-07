namespace Task2_1;

public class QuadraticEquationSolver
{
    private QuadraticEquation _equation;
    private readonly double[] _emptySolution = {0.0,0.0};

    public double[] Solve(QuadraticEquation equation)
    {
        _equation = equation;

        var discriminant = GetDiscriminant();
        return discriminant < 0 ? _emptySolution : GetSolution(discriminant);
    }

    private double GetDiscriminant() => _equation.B * _equation.B - 4 * _equation.A * _equation.C;

    private double[] GetSolution(double discriminant) => 
        new[]{GetX(discriminant, false), GetX(discriminant, true)};

    private double GetX(double discriminant, bool sign) => 
        (-_equation.B + Math.Sqrt(discriminant) * (sign ? 1 : -1)) / (2 * _equation.A);
}