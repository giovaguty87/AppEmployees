using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProcessCalculateSalaryMonthly
/// </summary>
public class ProcessCalculateSalaryMonthly : ICalculateSalary
{
    public ProcessCalculateSalaryMonthly()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int calculateSalary()
    {
        var response = 800000 * 12 ;

        return response;
    }
}