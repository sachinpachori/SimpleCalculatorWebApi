using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.String;

namespace CalculatorApp
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string result = Empty;
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            RunAsync().GetAwaiter().GetResult(); 
        }

        static async Task RunAsync()
        {            
            client.BaseAddress = new Uri("http://localhost:51322/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {               
               

                await Calculate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static async Task Calculate()
        {           
            Console.WriteLine("Enter 1st number:");
            string first = Console.ReadLine();
            if (IsNullOrWhiteSpace(first))
                Console.WriteLine("Invalid input");
            else
            {
                int.TryParse(first, out int fNum);
                Console.WriteLine("Enter 2nd number:");
                string second = Console.ReadLine();
                if (IsNullOrWhiteSpace(second))
                    Console.WriteLine("Invalid input");
                else
                {
                    int.TryParse(second, out int sNum);
                    Console.WriteLine("Enter the operation(A for Add, S for Subtract, M for Multiply, D for Divide):");
                    string operation = Console.ReadLine();

                    switch (operation)
                    {
                        case "A":
                            await AddNumbersAsync(fNum, sNum);
                            break;
                        case "S":
                            await SubtractNumbersAsync(fNum, sNum);
                            break;
                        case "M":
                            await MultiplyNumbersAsync(fNum, sNum);
                            break;
                        case "D":
                            await DivideNumbersAsync(fNum, sNum);
                            break;
                        default:
                            Console.WriteLine("Invalid operation choice");
                            break;
                    }                    
                }
            }
            Console.WriteLine("Press enter to start again....");
            Console.ReadLine();
            await Calculate();
        }

        private static async Task AddNumbersAsync(int FNum, int SNum)
        {
            try
            {
                string action = "add";
                string URI = $"api/SimpleCalculator/{FNum}/{SNum}/{action}";              
              
                HttpResponseMessage response = await client.GetAsync(URI);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
       
        private static async Task SubtractNumbersAsync(int FNum, int SNum)
        {
            string action = "subtract";
            string URI = $"api/SimpleCalculator/{FNum}/{SNum}/{action}";
            

            HttpResponseMessage response = await client.GetAsync(URI);
                                
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(Environment.NewLine + result);
        }

        private static async Task MultiplyNumbersAsync(int FNum, int SNum)
        {
            string action = "multiply";
            string URI = $"api/SimpleCalculator/{FNum}/{SNum}/{action}";
           
            HttpResponseMessage response = await client.GetAsync(URI);
            
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(Environment.NewLine + result);            
        }

        private static async Task DivideNumbersAsync(int FNum, int SNum)
        {
            string action = "divide";
            string URI = $"api/SimpleCalculator/{FNum}/{SNum}/{action}";

            HttpResponseMessage response = await client.GetAsync(URI);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            if (result.ToString() == "\"-999\"")
                Console.WriteLine(Environment.NewLine + result +':'+ "Divide by Zero Exception" );
            else
                Console.WriteLine(Environment.NewLine + result); 
        }
    }
}
