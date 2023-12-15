using System.ComponentModel.DataAnnotations;

namespace Exercise1.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal AddValues(decimal valueOne, decimal valueTwo)
        {
            return valueOne + valueTwo;
        }
    }

}
