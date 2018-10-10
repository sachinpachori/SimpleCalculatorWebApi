using System;
using static System.String;

namespace SimpleCalculator.Services
{
    public class SimpleCalculatorService : ISimpleCalculatorService 
    {
        private IDiagnosticsService _diagnostics;
        
        string opResult = Empty;
        public SimpleCalculatorService(IDiagnosticsService Diagnostics)
        {
            _diagnostics = Diagnostics;            
        }

        public int Add(int start, int amount)
        {
            var result = start + amount;
            opResult = result.ToString();
            _diagnostics.LogToDB(opResult);
           
            return result;
        }

        public int Subtract(int start, int amount)
        {
            var result = start - amount;
            opResult = result.ToString();
            _diagnostics.LogToDB(opResult);

            return result;
        }

        public int Multiply(int start, int by)
        {
            var result = start * by;
            opResult = result.ToString();
            _diagnostics.LogToDB(opResult);           

            return result;
        }
      
        public int Divide(int start, int by)
        {
            try
            {
                var result = start / by;
                opResult = result.ToString();
                _diagnostics.LogToDB(opResult);

                return result;
            }
            catch(DivideByZeroException ex)
            {
                return -999;
            }
        } 
    }
}
