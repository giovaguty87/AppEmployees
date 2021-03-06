﻿
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de ServiceClientUtilities
/// </summary>
public class DatabaseUtilities
{
    private static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
    private static SqlConnection cn;

    public DatabaseUtilities()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static void GetContractType(DropDownList ddlContractTypes)
    {
        //List<Users> lstUsers = new List<Users>();

        try
        {
            SqlDataReader sqldr;

            string cmdText = "SELECT [Id],[Description] FROM [dbo].[ContractType]";

            using (cn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                cmd.CommandType = CommandType.Text;
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                sqldr = cmd.ExecuteReader();

                ddlContractTypes.DataSource = sqldr;
                ddlContractTypes.DataTextField = "Description";
                ddlContractTypes.DataValueField = "Id";
                ddlContractTypes.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static int SaveInformationEmployee(string name,string lastname,int contractType,string hourSalary, string monthSalary)
    {
        int resp = 0;

        try
        {
            using (cn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[SaveEmployee]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastname;
                    cmd.Parameters.Add("@typeContract", SqlDbType.Int).Value = contractType;
                    cmd.Parameters.Add("@HourSalary", SqlDbType.Int).Value = hourSalary;
                    cmd.Parameters.Add("@MonthSalary", SqlDbType.Int).Value = monthSalary;

                    if (cn.State != ConnectionState.Open)
                        cn.Open();

                    resp = cmd.ExecuteNonQuery();

                    return resp;
                }
            }
        }
        catch (Exception ex)
        {
            return resp;
            throw ex;
        }
    }

    public static List<Employee> GetInformationEmployee(int id)
    {
        SqlDataReader sqldr;
        List<Employee> lstEmployees = new List<Employee>();

        try
        {
            using (cn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GetEmployees]", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    

                    if (cn.State != ConnectionState.Open)
                        cn.Open();

                    sqldr = cmd.ExecuteReader();

                    while (sqldr.Read())
                    {
                        var Emp = new Employee
                        {
                            Name = sqldr.GetString(0),
                            LastName = sqldr.GetString(1),
                            contractTypeName = sqldr.GetString(2),
                            hourlySalary = sqldr.GetString(3),
                            monthlySalary = sqldr.GetString(4),
                        };

                        lstEmployees.Add(Emp);
                    }

                    return lstEmployees;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}