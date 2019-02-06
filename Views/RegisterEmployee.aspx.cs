
using System;
using System.Web.UI;
using Common.Logging;
using System.Text.RegularExpressions;

public partial class RegisterEmployee : Page
{
    private readonly ILog _log;
    public int countSuccess;
    public int countFail;

    public RegisterEmployee()
    {
        _log = LogManager.GetLogger(GetType());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            btnCheckCalculations_Click(this, e);
        }

        cmbContractType.Items.Add("HourlySalaryEmployee");
        cmbContractType.Items.Add("MonthlySalaryEmployee");
    }

    protected void btnCheckCalculations_Click(object sender, EventArgs e)
    {
        try
        {
            int typeContract = 1;

            if((string.IsNullOrEmpty(this.txtName.Text)||(string.IsNullOrEmpty(this.txtLastName.Text))))
            {
                this.lblResponse.Text = "Please type the information for name or lastname.";
                _log.Error("Error, mandatroy information");
            }
            else
            {
                switch (cmbContractType.Text)
                {
                    case "Monthly":
                        typeContract = 2;
                        break;
                }                    

                var resultDB = DatabaseUtilities.SaveInformationEmployee(this.txtName.Text, this.txtLastName.Text, typeContract,this.TxtBoxHourlySalary.Text,
                    this.TxtBoxMonthlySalary.Text);

                if(Convert.ToBoolean(resultDB))
                    this.lblResponse.Text = "Save information succesfully.";
                else
                    this.lblResponse.Text = "There's a problem with the DB connection.";


                this.txtName.Text = string.Empty;
                this.txtLastName.Text = string.Empty;
                this.TxtBoxHourlySalary.Text = string.Empty;
                this.TxtBoxMonthlySalary.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            countFail++;
            _log.Error($"Error response : {ex.Message}");
            this.lblResponse.Text = ex.Message;
        }
        finally
        {
            
        }
    }
}