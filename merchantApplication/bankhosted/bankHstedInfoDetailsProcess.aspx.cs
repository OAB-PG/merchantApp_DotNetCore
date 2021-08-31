using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace merchantApplication.bankhosted
{
    public partial class bankHstedInfoDetailsProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                String id = "ipay************";    // Merchant tranportal Id // Replace with tranportal Id which received from Oman Arab Bank in email
                String password = "************";    // Merchant tranportal password // Replace with the tranportal password which received from Oman Arab Bank in email
                string key = "70736************"; // Merchant resource key // Replace with the resource key which received from Oman Arab Bank in email
                string pgendpoint = "https://certpayments.oabipay.com/trxns/PaymentHTTP.htm?param=paymentInit&";
                 String receiptURL = "http://localhost:54838/bankhosted/bankHstedResponsePage.aspx";     // URL where want to receive the payment response from the payment gateway
                String errorURL = "http://localhost:54838/bankhosted/bankHstedResponsePage.aspx";       // URL where want to receive the payment error if in payment gateway
                String currency = "512";    // Oman Currency
                string action = "1";
                string tokenNumber = Session["transTokenNumber"].ToString();
                string tranrequest = "amt="+ Session["transAmount"].ToString() +
                                        "&action="+ action+
                                        "&responseURL=" + receiptURL +
                                        "&errorURL=" + errorURL +
                                        "&trackId=" + Session["transTrackId"].ToString() +
                                        "&udf1=" + Session["transUdf1"].ToString() +
                                        "&udf2=" + Session["transUdf2"].ToString() +
                                        "&udf3=" + Session["transUdf3"].ToString() +
                                        "&udf4=" + Session["transUdf4"].ToString() +
                                        "&udf5=" + Session["transUdf5"].ToString() +
                                        "&currencycode="+ currency +
                                        "&langid=EN"+
                                        "&id=" + id +
                                        "&password=" + password +
                                        "&"
                                        ;
                if (tokenNumber != null && tokenNumber.Trim().Length != 0) {
                    tranrequest = tranrequest + "tokenNumber=" + tokenNumber + "&tokenFlag=2&";
                }
                

                byte[] results;
                StringBuilder sb = null;
                var tripleDESAlgorithm = new TripleDESCryptoServiceProvider() { Mode = CipherMode.ECB, Padding = PaddingMode.Zeros };
                tripleDESAlgorithm.Key = Encoding.ASCII.GetBytes(key);
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(tranrequest);
                try{
                    ICryptoTransform encryptor = tripleDESAlgorithm.CreateEncryptor();
                    results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                    encryptor.Dispose();
                } finally {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    tripleDESAlgorithm.Clear();
                }
                sb = new StringBuilder(results.Length * 2);
                foreach (byte b in results)
                {
                    sb.Append(b.ToString("x").PadLeft(2, '0'));
                }
                string encrypttranrequest = "&trandata="+sb.ToString();
                encrypttranrequest = encrypttranrequest + "&errorURL=" + errorURL;
                encrypttranrequest = encrypttranrequest + "&responseURL=" + receiptURL;
                encrypttranrequest = encrypttranrequest + "&tranportalId=" + id;

                string finalRequest = pgendpoint + encrypttranrequest;
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                StringBuilder s = new StringBuilder();
                s.Append("<html>");
                s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
                s.AppendFormat("<form name='form' action='{0}' method='post'>", pgendpoint);
                s.AppendFormat("<input type='hidden' name='trandata' value='{0}' />", sb.ToString());
                s.AppendFormat("<input type='hidden' name='errorURL' value='{0}' />", errorURL);
                s.AppendFormat("<input type='hidden' name='responseURL' value='{0}' />", receiptURL);
                s.AppendFormat("<input type='hidden' name='tranportalId' value='{0}' />", id);
                s.Append("</form></body></html>");
                response.Write(s.ToString());
                response.End();

               // Response.Redirect(finalRequest, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}