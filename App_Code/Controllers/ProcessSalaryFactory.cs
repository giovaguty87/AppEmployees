using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProcessSalaryFactory
/// </summary>
public class ProcessSalaryFactory
{
    public ProcessSalaryFactory()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public ICalculateSalary GetContractType(string contractType)
    {
        switch (contractType)
        {
            case "MonthlySalaryEmployee":
                {
                    return new ProcessCalculateSalaryMonthly();
                }
            case "HourlySalaryEmployee":
                {
                    return new ProcessCalculateSalaryHourly();
                }

            default: throw new ArgumentNullException("contractType");
        }
    }
}