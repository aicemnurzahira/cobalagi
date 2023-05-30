using SimpleEmployeeApp.Helpers.Model;
using SimpleEmployeeApp.Helpers.Service;
using System.Globalization;

namespace SimpleInMemoryCRUDEmployeeApp
{
    class Program
    {
        // initiate the Employee Service that contains List<Employee> which will be used to store and delegate the CRUD functions
        static EmployeeService employeeService = new EmployeeService();

        static void Main(string[] args)
        {
            // infinite loop for re-run the application when the task completed.
            while (true)
            {
                // initiate the program information
                Output.Message("Selamat datang di Aplikasi Karyawan CRUD Sederhana", Message.Type.Default);
                Output.Message("1. Daftar Karyawan", Message.Type.Default);
                Output.Message("2. Perbarui data karyawan", Message.Type.Default);
                Output.Message("3. Hapus data karyawan", Message.Type.Default);
                Output.Message("4. Daftar karyawan", Message.Type.Default);
                Output.Message("5. Keluar\n\n", Message.Type.Default);
                Output.Message("Pilihan anda: ", Message.Type.Default);

                // variable declaration for user input/number validation
                string? strChoice;
                bool IsValidNumber;

                // re-do the task if input was not a valid number
                do
                {
                    try
                    {
                        // read the user input and store it to a variable to be validated.
                        strChoice = Console.ReadLine();

                        // input validation
                        IsValidNumber = int.TryParse(strChoice, out int choice);
                        if (IsValidNumber)
                        {
                            switch (choice)
                            {
                                case 1:
                                    // create new record of employee task
                                    employeeService.CreateEmployee();
                                    break;
                                case 2:
                                    // update a single employee record task
                                    employeeService.UpdateEmployee();
                                    break;
                                case 3:
                                    // delete a single employee record task
                                    employeeService.DeleteEmployee();
                                    break;
                                case 4:
                                    // list of all employees
                                    employeeService.ListEmployee();
                                    break;
                                case 5:
                                    // exit / break the application
                                    return;
                                default:
                                    // send the output that user not type the option/choice correctly
                                    Output.Message("Pilihan tidak tersedia. Silakan coba lagi.", Message.Type.Warning);
                                    IsValidNumber = false;
                                    break;
                            }
                        }
                        // if user send a null or empty input
                        else if (string.IsNullOrEmpty(strChoice))
                        {
                            Output.Message("Mohon masukkan pilihan anda.", Message.Type.Warning);
                        }
                        // if user send non-integer input
                        else
                        {
                            Output.Message("Nomor tidak valid. Silakan coba lagi.", Message.Type.Warning);
                        }
                    }
                    // if program detects error then throw the error exception
                    catch (Exception ex)
                    {
                        Output.Message($"Error: {ex.Message}", Message.Type.Error);
                        IsValidNumber = false;
                    }
                } while (!IsValidNumber);
            }
        }
    }
}