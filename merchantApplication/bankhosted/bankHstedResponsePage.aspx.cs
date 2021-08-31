using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace merchantApplication.bankhosted
{
    
    public partial class bankHstedResponsePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string StrTrandata = "", Strdata = "", strval1 = "";
            if (Request.Form.Count != 0)
            {
                StrTrandata = Request.Form["trandata"].ToString();
            }
            if (Request.QueryString.Count != 0)
            {
                Strdata = Request.QueryString.GetKey(0);
                Request.QueryString[0].ToString();
                StrTrandata = Request.QueryString[Strdata].ToString();
            }
            strval1 = StrTrandata.ToString();
            Console.WriteLine("Enc Response : " + strval1);
            if (StrTrandata.Contains("ErrorText"))
            {

            }
            else
            {
                String Key = "********************************";  // Merchant resource key // Replace with the resource key which received from Oman Arab Bank in email
                byte[] key = Encoding.ASCII.GetBytes(Key);
                int NumberChars = StrTrandata.Length / 2;
                byte[] data = new byte[NumberChars];
                StringReader sr = new StringReader(StrTrandata);
                for (int i = 0; i < NumberChars; i++)
                    data[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
                sr.Dispose();
                byte[] enc = new byte[0];
                TripleDES tdes = TripleDES.Create();
                tdes.Key = key;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.Zeros;
                ICryptoTransform ict = tdes.CreateDecryptor();
                enc = ict.TransformFinalBlock(data, 0, data.Length);
                String decryptedStr = Encoding.ASCII.GetString(enc);
                if (decryptedStr.StartsWith("<")) {
                    decryptedStr = decryptedStr.Substring(0, decryptedStr.LastIndexOf('>') + 1);
                } else {
                     decryptedStr = decryptedStr.Substring(0, decryptedStr.LastIndexOf('&') + 1);
                }
                Console.WriteLine("Result" + decryptedStr);

                var responsemap = new Dictionary<string, string>();
                
                string value = null;
                decryptedStr = decryptedStr.Trim();
                string errorTxt = "";
                string[] lines = System.Text.RegularExpressions.Regex.Split(decryptedStr, "&");
                foreach (string line in lines)
                {
                    if (line == null || line.Trim().Length == 0)
                        continue;
                    string[] lines1 = System.Text.RegularExpressions.Regex.Split(line, "=");
                    responsemap.Add(lines1[0], lines1[1]);
                }
                lblErr.Text = errorTxt;
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


        }
    }
}