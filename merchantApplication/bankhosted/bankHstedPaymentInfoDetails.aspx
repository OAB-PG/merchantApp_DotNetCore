<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="bankHstedPaymentInfoDetails.aspx.cs" Inherits="merchantApplication.bankhosted.bankHstedPaymentInfoDetails" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <script language="C#" runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bnkHstdtrackId.Text = DateTime.Now.ToString("ddMMyyyyhhmmss");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        finally
        {

        }
    }


    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            
            Session["transAmount"] = bnkHstdamount.Text.Trim();
            Session["tokenNumber"] = bnkHstdamount.Text.Trim();
                
            Session["transUdf1"] = bnkHstdudf1.Text.Trim();
            Session["transUdf2"] = bnkHstdudf2.Text.Trim();
            Session["transUdf3"] = bnkHstdudf3.Text.Trim();
            Session["transUdf4"] = bnkHstdudf4.Text.Trim();
            Session["transUdf5"] = bnkHstdudf5.Text.Trim();
            Session["transTrackId"] = bnkHstdtrackId.Text.Trim();
            Session["transTokenNumber"] = tokenNumber.Text.Trim();
                
            Response.Redirect("bankHstedInfoDetailsProcess.aspx", false);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        finally
        {

        }
    }

    </script>
 
<link rel="stylesheet" href="./css/bootstrap.min.css">
<script src="./css/jquery.min.js"></script>
<script src="./css/bootstrap.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

    <div class="container">
	<div class="panel panel-default">
		<div class="panel-body">
    <form id="form1">

   

				<div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">Amount</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="bnkHstdamount" name="bnkHstdamount" value="0.100" />
					</div>
				</div>

                <div class="form-group row">
					<label for="tokenLbl" class="col-sm-3 col-form-label">Token Number</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="tokenNumber" name="tokenNumber" value="" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 1</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdudf1" name="bnkHstdudf1" value="udf 111 value" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 2</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdudf2" name="bnkHstdudf2" value="udf 222 value" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 3</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdudf3" name="bnkHstdudf3" value="udf 333 value" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 4</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdudf4" name="bnkHstdudf4" value="udf 444 value" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 5</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdudf5" name="bnkHstdudf5" value="udf 555 value" />
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">Track Id</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="bnkHstdtrackId" name="bnkHstdtrckId" value="" />
					</div>
				</div>

                <div class="form-group row">
					<label for="expireDateLbl" class="col-sm-3 col-form-label"></label>
					<div class="col-sm-4">
						<asp:Button ID="Submit" runat="server" Text="Process" OnClick="Submit_Click" />
					</div>
				</div>




</form>
</div>
        </div></div>
        <script>
            document.getElementById("merchanthstd").className = "";
            document.getElementById("merchanthstdvbv").className = "active";
            document.getElementById("mercahnthostedinquiry").className = "";
            document.getElementById("bankhosted").className = "";
    </script>
</asp:Content>