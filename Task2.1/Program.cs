using Common;

namespace Task2_1
{
    public static class Program
    {
        private static readonly QuadraticEquationSolver _equationSolver = new();
        private static readonly QuadraticEquation _equationX = new(3, -6, 1);
        private static readonly QuadraticEquation _equationY = new(2, -1, 4);
        
        public static void Main()
        {
            Outputter.Init();
            Inputter.GetInput("Введіть значення t для обчислення виразу: ", out double t);
            
            var solutionX = _equationSolver.Solve(_equationX);
            var solutionY = _equationSolver.Solve(_equationY);

            ValidateSolution(ref solutionX);
            ValidateSolution(ref solutionY);

            var result = CalculateResult(solutionX, solutionY, t);
            var resultMessage = double.IsRealNumber(result) ? result.ToString() : "комплексне число";
            Console.WriteLine($"\nРезультат обчислень: {resultMessage}.");
        }

        private static void ValidateSolution(ref double[] solution) => 
            solution = solution[1] > solution[0] ? solution : solution.Reverse().ToArray();

        private static double CalculateResult(double[] solutionX, double[] solutionY, double t) =>
            CalculateResultPart(t, solutionX[0], solutionY[0])
            + CalculateResultPart(Math.E, solutionX[1], -solutionY[1]);

        private static double CalculateResultPart(double main, double pow1, double pow2) => Math.Pow(main, pow1 + pow2);
    }
}