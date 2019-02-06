using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CalculationsUtils
/// </summary>
public class CalculationsUtils
{
    public CalculationsUtils()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}