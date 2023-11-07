using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    internal class Class1
    {
    }
}
using System;

public class Calculator<T>
{
    public delegate T OperationDelegate(T a, T b);

    public OperationDelegate Add { get; set; }
    public OperationDelegate Subtract { get; set; }
    public OperationDelegate Multiply { get; set; }
    public OperationDelegate Divide { get; set; }

    public Calculator()
    {
        // Додавання
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Add = (a, b) => (dynamic)a + b;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Віднімання
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Subtract = (a, b) => (dynamic)a - b;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Множення
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Multiply = (a, b) => (dynamic)a * b;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Ділення
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Divide = (a, b) => (dynamic)a / b;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }

    public T PerformOperation(T a, T b, OperationDelegate operation)
    {
        if (operation != null)
            return operation(a, b);
        else
            throw new InvalidOperationException("Operation is not defined.");
    }
}
