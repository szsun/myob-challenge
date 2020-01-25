using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaySlipConsole.Model;
using Serilog;
using System;

namespace PaySlipConsole
{
    /**
     * this console application gives the details of a payslip given employee's anual salary.
     * the payslip is monthly while it can be exteneded to support other period like weekly, fornightly and yearly.
     * the tax calculation can also be extended to support other varies based on differernt locations and/or financial years.
     * 
     * console input:  employee name in string format and anual salary in positive numeric format
     * console output: employee name, gross income, income tax and net income on individual lines.
     * 
     * Assumptions:
     * 1. The app runs for one employee every time.
     * 2. The anual salary must be less than or equal to the max int number : 2147483647. Otherwise, the income tax will stay the same.
     * 3. The GrossIncome and IncomeTax are calculated and rounded to two fractional digits.
     * 4. The tax rates is assumed to be from Australia and for FY19.
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {            
            var logger = initLogger();
            logger.LogInformation("Application Started at {dateTime}", DateTime.UtcNow);
            if (!validArgs(args, logger))
            {
                logger.LogInformation("Application Ended at {dateTime}", DateTime.UtcNow);
                return;
            }
            string empName = args[0];
            double anualSalary = Double.Parse(args[1]);

            IEmployee emp = getEmployee(empName, anualSalary);
            // The payslip factory creates the payslip based on the employee's PaySlipPeriodType attribute.
            IPaySlip payslip = PaySlipFactory.generatePaySlip(emp);
            // each specific implementation of IPaySlip prints the details in particular format.
            payslip.PrintDetails();

            /*            emp.PaySlipPeriodType = PaySlipPeriodType.FORNIGHTLY;
                        payslip = PaySlipFactory.generatePaySlip(emp);
                        payslip.PrintDetails();*/
            logger.LogInformation("Application Ended at {dateTime}", DateTime.UtcNow);
        }

        private static Microsoft.Extensions.Logging.ILogger<Program> initLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("consoleapp.log")
          .CreateLogger();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            return logger;            
        }

        // the creation of employee can be extended to a service to support different type, eg, contract, parttime, etc.
        private static IEmployee getEmployee(string empName, double anualSalary)
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
        static bool validArgs(string[] args, Microsoft.Extensions.Logging.ILogger<Program> logger)
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
                if (salary < 0) {
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

        private static void ConfigureServices(IServiceCollection services)
        {
            //we will configure logging here
            services.AddLogging(configure => configure.AddSerilog())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
        }
    }
}
