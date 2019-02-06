using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

/// <summary>
/// Descripción breve de EstimateSalaryManager
/// </summary>
public class EstimateSalaryManager
{
    public EstimateSalaryManager()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public T RequestInfoEmployees<T>()
    {

        try
        {
            var requestUri = ConstantsUtils.MainURI;

            using (var client = new HttpClient())
            {
                var responseMessage = client.GetAsync(requestUri).Result;

                using (var content = responseMessage.Content)
                {
                    var responseBody = content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
        }
        catch (Exception ex)
        {
            return default(T);
            throw;
        }
    }
}