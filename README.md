# myob-challenge

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

     To Run the app from the exe file:
     1. open a console 
     2. switch to the attached PaySlip\publish folder that you've copied to your local.
     3. type command by the app's exe file name 'PaySlipConsole' and two arguments. eg: PaySlipConsole "Mary Song" 60000

     To Run the app from the source code:
     1. open the solution by visual studio or VS code
     2. open project properties setup menu for PaySlipConsole  -> Debug tab
     3. put the required two arguments in 'Application Arguments' input box, eg: "Mary Song" 60000
     4. save and press F5 to run.
