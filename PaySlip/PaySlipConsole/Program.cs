using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaySlipConsole.Model;
using Serilog;
using System;

namespace PaySlipConsole
{
    /**
     * This console application gives the details of a payslip based on employee's anual salary.
     * The payslip is by monthly while it can be exteneded to support other period like weekly, fornightly and yearly.
     * The tax calculation can also be extended to support various ones based on differernt locations and/or financial years.
     * 
     * Console input:  employee name in string format, and anual salary in positive numeric format.
     * Console output: employee name, gross income, income tax and net income on individual lines.
     * 
     * Assumptions:
     * 1. The app runs for one employee every time.
     * 2. The anual salary must be less than or equal to the max int number : 2147483647. Otherwise, the income tax will stay the same.
     * 3. The GrossIncome and IncomeTax are calculated and rounded to two fractional digits.
     * 4. The tax rates is assumed to be from Australia and for FY19.
     * 
     * A few OO design principles and patterns are used: 
     * Encapsulation, Inheritance, Polymophism, Composition, Programing to the interface, Factory pattern, Singleton pattern.
     * 
     * Logging framework Serilog is demoed in the main program.
     * 
     * The unit tests are prvoided in the test project that is based on xUnit and Moq.
     * 
     * @Author : Lei Sun
     * @Date: 2020-01-26
     */
    class Program
    {
        static void Main(string[] args)
        {
            var logger = InitLogger();
            logger.LogInformation("Application Started at {dateTime}", DateTime.UtcNow);
            if (!IsValidArgs(args, logger))
            {
                logger.LogInformation("Application Ended at {dateTime}", DateTime.UtcNow);
                return;
            }
            string empName = args[0];
            double anualSalary = Double.Parse(args[1]);

            IEmployee emp = GetEmployee(empName, anualSalary);
            // The payslip factory creates the payslip based on the employee's PaySlipPeriodType attribute.
            IPaySlip payslip = PaySlipFactory.CreatePaySlip(emp);
            payslip.Init();
            // each specific implementation of IPaySlip prints the details in particular format.
            payslip.PrintDetails();

/*            emp.PaySlipPeriodType = PaySlipPeriodType.FORNIGHTLY;
            payslip = PaySlipFactory.CreatePaySlip(emp);
            payslip.Init();
            payslip.PrintDetails();*/
            logger.LogInformation("Application Ended at {dateTime}", DateTime.UtcNow);
        }



        // the creation of employee can be extended to a service to support different type, eg, contract, parttime, etc.
        private static IEmployee GetEmployee(string empName, double anualSalary)
        {

            IEmployee emp = new PermanentEmployee(empName, anualSalary);
            // set the employee's payslip period to be monthly.
            emp.PaySlipPeriodType = PaySlipPeriodType.MONTHLY;
            // employee's payslip location might be different to the geo location.
            emp.PaySlipLocation = PaySlipLocation.AU;
            // The creation of tax calculator can be extended to a service that checks the employee's location, FY etc. 
            // In a international company, each employee might have a differeent tax regulation.
            emp.TaxCalculator = TaxCalculatorFactory.Instance.GetTaxCalculator(emp.PaySlipLocation, PaySlipFY.FY19);
            return emp;
        }

        /**
        * validate the input args to enforce the two args are provied as being expected.
        * give the warning for more arguements provided.
        */
        static bool IsValidArgs(string[] args, Microsoft.Extensions.Logging.ILogger<Program> logger)
        {
            if (args.Length < 2)
            {
                logger.LogError("Missing Arguments.");
                System.Console.WriteLine("Please enter employee name and anual salary.");
                Console.WriteLine("Usage: PaySlipConsole <string> <num>");
                return false;
            }
            try
            {
                double salary = Double.Parse(args[1]);
                if (salary < 0)
                {
                    logger.LogError("Minus number for Salary.");
                    System.Console.WriteLine("Please enter a positive numeric for anual salary.");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.LogError("Invalid number format for Salary.");
                System.Console.WriteLine("Please enter a numeric for anual salary.");
                return false;
            }
            if (args.Length > 2)
            {
                logger.LogWarning("Arguments after employee name and anual salary have been ignored.");
                System.Console.WriteLine("Warning: Arguments after employee name and anual salary have been ignored.");
            }
            return true;
        }

        // logging to file
        private static Microsoft.Extensions.Logging.ILogger<Program> InitLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("consoleapp.log")
          .CreateLogger();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            return logger;
        }
        // Serilog
        private static void ConfigureServices(IServiceCollection services)
        {
            //we will configure logging here
            services.AddLogging(configure => configure.AddSerilog())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
        }
    }
}
