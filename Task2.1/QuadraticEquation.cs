namespace Task2_1;

public class QuadraticEquation
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public QuadraticEquation(double a, double b, double c) => (A, B, C) = (a, b, c);
}