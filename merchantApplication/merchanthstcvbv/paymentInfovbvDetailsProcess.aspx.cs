using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace merchantApplication.merchanthstcvbv
{
    public partial class paymentInfovbvDetailsProcess : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                String id = "ipay************";    // Merchant tranportal Id // Replace with tranportal Id which received from Oman Arab Bank in email
                String password = "************";    // Merchant tranportal password // Replace with the tranportal password which received from Oman Arab Bank in email
                string key = "********************"; // Merchant resource key // Replace with the resource key which received from Oman Arab Bank in email
                string pgendpoint = "https://certpayments.oabipay.com/trxns/VPAS.htm?actionVPAS=VbvVEReqProcessHTTP&";
                 String receiptURL = "http://localhost:54838/merchanthstcvbv/paymentvbvResponsePage.aspx";     // URL where want to receive the payment response from the payment gateway
                String errorURL = "http://localhost:54838/merchanthstcvbv/paymentvbvResponsePage.aspx";       // URL where want to receive the payment error if in payment gateway
                String currency = "512";    // Oman Currency
                string action = "1";
                string tranrequest = "<request>" +
                                                "<card>"+ Session["transCardNumber"].ToString() + "</card>" +
                                                "<cvv2>"+ Session["transCvv"].ToString() + "</cvv2>" +
                                                "<currencycode>" + currency + "</currencycode>" +
                                                "<expyear>" + Session["transExpYYYY"].ToString() + "</expyear>" +
                                                "<expmonth>" + Session["transExpMM"].ToString() + "</expmonth>" +
                                                "<member>" + Session["transCardHolderName"].ToString() + "</member>" +
                                                "<amt>" + Session["transAmount"].ToString() + "</amt>" +
                                                "<action>" + action + "</action>" +
                                                "<trackid>" + Session["transTrackId"].ToString() + "</trackid>" +
                                                "<udf1>" + Session["transUdf1"].ToString() + "</udf1>" +
                                                "<udf2>" + Session["transUdf2"].ToString() + "</udf2>" +
                                                "<udf3>" + Session["transUdf3"].ToString() + "</udf3>" +
                                                "<udf4>" + Session["transUdf4"].ToString() + "</udf4>" +
                                                "<udf5>" + Session["transUdf5"].ToString() + "</udf5>" +
                                                "<currencycode>" + currency + "</currencycode>" +
                                                "<id>" + id + "</id>" +
                                                "<password>" + password + "</password>" +
                                           "</request>";


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

                Response.Redirect(finalRequest, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}