using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    public int countSuccess;
    public int countFail;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            btnSerialize_Click(this, e);
        }
    }

    protected void btnSerialize_Click(object sender, EventArgs e)
    {
        try
        {
            var response = "";

            this.txtResult.Text = response;
            this.lblResponse.Text = "Object serialized"; 

        }
        catch (Exception ex)
        {
            countFail++;
            //_log.Error($"Error response : {httpre.Message}");
            this.lblResponse.Text = ex.Message;
        }
        finally
        {
            
        }
    }

    private string SetRequest()
    {
        StringBuilder sbRequestWS = new StringBuilder();

        //Envelope
        sbRequestWS.AppendLine(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""");
        sbRequestWS.AppendLine(@"xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd""");
        sbRequestWS.AppendLine(@"xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd""");
        sbRequestWS.AppendLine(@"xmlns:ser=""http://service.sunat.gob.pe"">");
        //Header
        sbRequestWS.AppendLine(@"<soapenv:Header><wsse:Security><wsse:UsernameToken wsu:Id=""UsernameToken-1""><wsse:Username>ivan.ortiz@carvajal.com</wsse:Username>");
        sbRequestWS.AppendLine(@"<wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3</wsse:Password>");
        sbRequestWS.AppendLine(@"</wsse:UsernameToken></wsse:Security></soapenv:Header>");
        //Body
        sbRequestWS.AppendLine(@"<soapenv:Body><ser:getStatus><ticket>101081275126672 </ticket></ser:getStatus></soapenv:Body></soapenv:Envelope>");

        var request = sbRequestWS.ToString().Trim();

        return request;
    }
}