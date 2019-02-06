using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProcessCalculateSalaryMonthly
/// </summary>
public class ProcessCalculateSalaryHourly : ICalculateSalary
{
    public ProcessCalculateSalaryHourly()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int calculateSalary()
    {
        var response = 120 * 60000 * 12;

        return response;
    }
}