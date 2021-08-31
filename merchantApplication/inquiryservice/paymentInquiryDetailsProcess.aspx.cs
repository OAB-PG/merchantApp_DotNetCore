using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace merchantApplication.inquiryservice
{
    public partial class paymentInquiryDetailsProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string certLocation = "S:\\OAB Projects\\oabcert\\oabipay_com.crt"; // Download the domain certificate from (UAT ENV : https://certpayments.oabipay.com, Production Env : https://securepayments.oabipay.com) using browser
                String tranportalId = "ipay************";     // merchant tranportal Id // Replace with tranportal Id which received from Oman Arab Bank in email
                string tranportalPassword = "************";     // merchant tranportal password // Replace with the tranportal password which received from Oman Arab Bank in email
                String currency = "512";    // Oman Currency
                string pginquiryendpoint = "https://certpayments.oabipay.com/trxns/tranPipe.htm?param=tranInit";

                string inquirytranrequest = "<request>" +
                                                "<currencycode>" + currency + "</currencycode>" +
                                                "<transid>" + Session["transtranId"].ToString() + "</transid>" +
                                                "<amt>" + Session["transAmount"].ToString() + "</amt>" +
                                                "<action>"+ Session["transAction"].ToString() + "</action>" +
                                                "<trackid>" + Session["transTrackId"].ToString() + "</trackid>" +
                                                "<udf5>"+ Session["transUdf5"].ToString() + "</udf5>" +
                                                "<currencycode>"+ currency + "</currencycode>" +
                                                "<id>"+ tranportalId + "</id>" +
                                                "<password>" + tranportalPassword + "</password>" +
                                            "</request>";

                StreamWriter writer = null;
                HttpWebRequest request = null;
                X509Certificate Cert2 = null;
                HttpWebResponse webResponse = null;
                request = WebRequest.Create(string.Format(pginquiryendpoint, "valid")) as HttpWebRequest;
                Cert2 = X509Certificate.CreateFromCertFile(certLocation);
                request.ClientCertificates.Add(Cert2);
                request.Method = "POST";
                request.ContentType = "application/xml";//"text/xml; charset=utf-8";
                                                        // request.ContentLength = oabpipe.getServiceTranRequest().Length;
                request.KeepAlive = false;
                writer = new StreamWriter(request.GetRequestStream());
                writer.Write(inquirytranrequest);
                writer.Close();
                webResponse = (HttpWebResponse)request.GetResponse();
                Stream GetDataStream = webResponse.GetResponseStream();
                StreamReader GetDatafromStream = new StreamReader(GetDataStream);
                string inquiryResponse = GetDatafromStream.ReadToEnd();

                var responsemap = new Dictionary<string, string>();
                int begin = 0;
                int end = 0;
                string beginString = null;
                string value = null;
                inquiryResponse = inquiryResponse.Trim();
                string errorTxt = "";
                if ((inquiryResponse == null) || (!inquiryResponse.StartsWith("<")) || (inquiryResponse.Length < 0))
                {
                    errorTxt = "Invalid Response";
                }
                else
                {

                    do
                    {
                        beginString = inquiryResponse.Substring(inquiryResponse.IndexOf("<") + 1, inquiryResponse.IndexOf(">") - 1);
                        begin = inquiryResponse.IndexOf("<") + beginString.Length + 2;
                        end = inquiryResponse.IndexOf("</" + beginString) + 1;
                        value = inquiryResponse.Substring(begin, end - begin - 1);
                        end = end + beginString.Length + 3;
                        inquiryResponse = inquiryResponse.Substring(end - 1, inquiryResponse.LastIndexOf(">") - (end - 2));
                        responsemap.Add(beginString, value);
                        begin = 0;
                        end = 0;
                        beginString = "";
                    } while (inquiryResponse.Length > 0);
                }


                
                    transactionStatusLbl.Text = responsemap.ContainsKey("result") ? responsemap["result"] : "";
                postDateLbl.Text = responsemap.ContainsKey("postdate") ? responsemap["postdate"] : "";
                transactioreferencelbl.Text = responsemap.ContainsKey("ref") ? responsemap["ref"] : "";
                trackIdLbl.Text = responsemap.ContainsKey("trackid") ? responsemap["trackid"] : "";
                transactionIdLbl.Text = responsemap.ContainsKey("tranid") ? responsemap["tranid"] : "";
                transactionAmtLbl.Text = responsemap.ContainsKey("amt") ? responsemap["amt"] : "";
                udf1Lbl.Text = responsemap.ContainsKey("udf1") ? responsemap["udf1"] : "";
                udf2Lbl.Text = responsemap.ContainsKey("udf2") ? responsemap["udf2"] : "";
                udf3Lbl.Text = responsemap.ContainsKey("udf3") ? responsemap["udf3"] : "";
                udf4Lbl.Text = responsemap.ContainsKey("udf4") ? responsemap["udf4"] : "";
                udf5Lbl.Text = responsemap.ContainsKey("udf5") ? responsemap["udf5"] : "";
                paymentidLbl.Text = responsemap.ContainsKey("paymentid") ? responsemap["paymentid"] : "";
                tokenNumber.Text = responsemap.ContainsKey("tokencustid") ? responsemap["tokencustid"] : "";



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}