using System.Globalization;

Console.WriteLine("enter file full path:");
string path = Console.ReadLine();

List<Employee> employees = new List<Employee>();

using (StreamReader sr = new StreamReader(path))
{
    while (!sr.EndOfStream)
    {
        string[] fields = sr.ReadLine().Split(',');
        string name = fields[0];
        string email = fields[1];
        double salary = double.Parse(fields[2] , CultureInfo.InvariantCulture);
        employees.Add(new Employee(name, email, salary));
    }
}
Console.WriteLine("enter the salary range:");
double salaryRange = double.Parse(Console.ReadLine());
var emails = employees.Where(e => e.Salary > salaryRange).OrderBy(e => e.Email).Select( e => e.Email);

Console.WriteLine("email of people whose salary is more than " + salaryRange.ToString("F2", CultureInfo.InvariantCulture));
foreach (string e in emails)
{
    Console.WriteLine(e);
}
var salarySum = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
Console.WriteLine("sum of salary of people whose name starts with 'M': " + salarySum.ToString("F2", CultureInfo.InvariantCulture));