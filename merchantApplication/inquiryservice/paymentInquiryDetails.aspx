<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="paymentInquiryDetails.aspx.cs" Inherits="merchantApplication.inquiryservice.paymentInquiryDetails" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <script language="C#" runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mrchHstVbvtrackId.Text = DateTime.Now.ToString("ddMMyyyyhhmmss");
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
            
            Session["transAmount"] = mrchHstVbvamount.Text.Trim();
            Session["transAction"] = mrchHstaction.SelectedValue.ToString();
                
            Session["transtranId"] = mrchHstTranId.Text.Trim();
            Session["transUdf1"] = mrchHstVbvudf1.Text.Trim();
            Session["transUdf2"] = mrchHstVbvudf2.Text.Trim();
            Session["transUdf3"] = mrchHstVbvudf3.Text.Trim();
            Session["transUdf4"] = mrchHstVbvudf4.Text.Trim();
            Session["transUdf5"] = mrchHstVbvudf5.SelectedValue.ToString();
            Session["transTrackId"] = mrchHstVbvtrackId.Text.Trim();
            Response.Redirect("paymentInquiryDetailsProcess.aspx", false);

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
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstVbvamount" name="amount" value="0.100" />
					</div>
				</div>
    			<div class="form-group row">
					<label for="mrchHstactionLbl" class="col-sm-3 col-form-label">Action</label>
					<div class="col-sm-3">
						<asp:DropDownList class="form-control" id="mrchHstaction" runat="server">
                            <asp:ListItem Text="Cancel Purchase" Value="3"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="Inquiry" Value="8"></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>

                <div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">Tran Id</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstTranId" name="mrchHstTranId" value="" />
					</div>
				</div>

                <div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">UDF 1</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstVbvudf1" name="mrchHstVbvudf1" value="" />
					</div>
				</div>

                <div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">UDF 2</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstVbvudf2" name="mrchHstVbvudf2" value="" />
					</div>
				</div>
                <div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">UDF 3</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstVbvudf3" name="mrchHstVbvudf3" value="" />
					</div>
				</div>
                <div class="form-group row">
					<label for="ActionLbl" class="col-sm-3 col-form-label">UDF 4</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" class="form-control" size="20"  id="mrchHstVbvudf4" name="mrchHstVbvudf4" value="" />
					</div>
				</div>


				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">UDF 5</label>
					<div class="col-sm-3">
						<asp:DropDownList class="form-control" id="mrchHstVbvudf5" runat="server">
                            <asp:ListItem Text="PaymentID" Value="PaymentID"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="TrackID" Value="TrackID"></asp:ListItem>
                            <asp:ListItem Text="SeqNum" Value="SeqNum"></asp:ListItem>
                            <asp:ListItem Text="Original Transaction Id" Value=""></asp:ListItem>
                        </asp:DropDownList>
					</div>
				</div>

				<div class="form-group row">
					<label for="cardHolderLbl" class="col-sm-3 col-form-label">Track Id</label>
					<div class="col-sm-3">
						<asp:TextBox runat="server" type="text" class="form-control" size="20" id="mrchHstVbvtrackId" name="trckId" value="" />
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
            document.getElementById("merchanthstdvbv").className = "";
            document.getElementById("bankhosted").className = "";
            document.getElementById("mercahnthostedinquiry").className = "active";
    </script>
</asp:Content>