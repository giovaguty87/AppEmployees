using Common.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class EstimateSalary : Page
{
    private readonly EstimateSalaryManager _estimateSalaryManager = new EstimateSalaryManager();
    private readonly ILog _log;
    public int countSuccess;
    public int countFail;

    public EstimateSalary()
    {
        _log = LogManager.GetLogger(GetType());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            btnInfoAPI_Click(this, e);
        }               
    }

    protected void btnListInfo_Click(object sender, EventArgs e)
    {
        try
        {
            ProcessSalaryFactory processFactory = new ProcessSalaryFactory();

            if (!CalculationsUtils.IsDigitsOnly(txtUsuario.Text))
            {
                this.lblResponse.Text = "Please type Id's employee in order to estimate your salary.";
                _log.Error("Error, mandatroy information");
            }
            else
            {
                int IdEmp = 0;

                if (!string.IsNullOrEmpty(txtUsuario.Text))
                    IdEmp = Convert.ToInt16(txtUsuario.Text);

                var lstEmp = DatabaseUtilities.GetInformationEmployee(IdEmp);

                this.lblResponse.Text = "Employee info : " + "</br>";
                

                if (lstEmp.Count > 0)
                {
                    _log.Info("Employee info found.");

                    _log.Info($"{lstEmp.Count} : Employees for process.");

                    foreach (var emp in lstEmp)
                    {
                        var contract = processFactory.GetContractType(emp.contractTypeName);

                        emp.totalSalary = Convert.ToString(contract.calculateSalary());
                    }

                    this.gvInfoEmployees.DataSource = lstEmp;
                    this.gvInfoEmployees.DataBind();
                    
                }
                else
                {
                    this.gvInfoEmployees.DataSource = null;
                    this.lblResponse.Text = "Info not found.! ";
                    _log.Warn("Info not found in API.!");
                }
            }
        }
        catch (Exception ex)
        {
            countFail++;
            this.lblResponse.Text = ex.Message;
            _log.Error("Excepcion : " + ex.Message);
        }
        finally
        {

        }
    }

    protected void btnInfoAPI_Click(object sender, EventArgs e)
    {
        try
        {
            ProcessSalaryFactory processFactory = new ProcessSalaryFactory();

            if (!CalculationsUtils.IsDigitsOnly(txtUsuario.Text))
            {
                this.lblResponse.Text = "Please type Id's employee in order to estimate your salary.";
                _log.Error("Error, mandatory information");
            }
            else
            {

                var dataRetrievedEmployee = _estimateSalaryManager.RequestInfoEmployees<JArray>();

                if(dataRetrievedEmployee != null)
                {
                    _log.Info("Employee info found.");

                    JArray jsonResponse = JArray.Parse(dataRetrievedEmployee.ToString());

                    var lstEmployees = JsonConvert.DeserializeObject<List<Employee>>(jsonResponse.ToString());

                    if(lstEmployees.Count > 0)
                    {
                        _log.Info($"{lstEmployees.Count} : Employees for process.");

                        this.lblResponse.Text = "Employee info : " + "</br>";

                        foreach (var emp in lstEmployees)
                        {
                            var contract = processFactory.GetContractType(emp.contractTypeName);

                            emp.totalSalary = Convert.ToString(contract.calculateSalary());
                        }

                        this.gvInfoEmployees.DataSource = lstEmployees;
                        this.gvInfoEmployees.DataBind();
                    }
                    else
                    {
                        this.lblResponse.Text = "Info not found : ";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            this.lblResponse.Text = ex.Message;
            throw;
        }
        finally
        {

        }
    }
}