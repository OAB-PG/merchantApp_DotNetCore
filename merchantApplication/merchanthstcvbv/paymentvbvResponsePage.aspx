<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentvbvResponsePage.aspx.cs" Inherits="merchantApplication.merchanthstcvbv.paymentvbvResponsePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/css/payments-inter.css" rel="stylesheet" type="text/css" />
    <link href="~/css/main.css" rel="stylesheet" type="text/css" />
    <title>Bank Hosted Response Page </title>

    <style>

        .clr {
    overflow: hidden;
}

.mer-logo-wrap {
    text-align: left;
    padding-left: 35px;
}

.header-table {
    width: 100%;
}

    .header-table td {
        vertical-align: middle;
        width: 49.9%;
    }

.mer-logo-wrap > img {
    max-height: 75px;
}

.payz-logo-wrap {
    text-align: right;
    padding-right: 35px;
}

.norm-hd {
    padding: 15px 0;
    position: relative;
    z-index: 1000;
    border-bottom: 1px solid #e5e5e5;
}

.success-info {
    background: none repeat scroll 0 0 #dff2de;
    border: 2px solid #468847;
    color: #000000;
}

    .success-info font {
        color: green;
    }

.failure-info font {
    color: red;
}



    </style>
</head>
 <form runat="server">
    <div class="wrap" id="detect-iframe">
        	<table class="info success-info" runat="server" >
				<tr>
					<td>
						<table align="center">
							<tr>
								<td colspan="2" align="center">
									<h2><B>Transaction Details   </B></h2>
								</td>
							</tr>
                            <tr>
								<td>Error</td>
                                <td> &nbsp;&nbsp;<b><font size="2" color="red">
                                    <asp:Label ID="lblErr" runat="server"></asp:Label></font></b>
                                </td>
							</tr>
							<tr>
								<td>Transaction Status</td><td> &nbsp;&nbsp;<b><font size="2" color="red"><asp:Label ID="transactionStatusLbl" runat="server"></asp:Label></font></b></td>
							</tr>
							<tr>
								<td>Post Date</td><td> &nbsp;&nbsp;<asp:Label ID="postDateLbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Transaction Reference ID</td><td>&nbsp;&nbsp;<asp:Label ID="transactioreferencelbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Mrch Track ID</td><td>&nbsp;&nbsp;<asp:Label ID="trackIdLbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td><b>Transaction ID</b></td><td>&nbsp;&nbsp;<asp:Label ID="transactionIdLbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Transaction Amount</td><td>&nbsp;&nbsp;<asp:Label ID="transactionAmtLbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>UDF1</td><td>&nbsp;&nbsp;<asp:Label ID="udf1Lbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>UDF2</td><td>&nbsp;&nbsp;<asp:Label ID="udf2Lbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>UDF3</td><td>&nbsp;&nbsp;<asp:Label ID="udf3Lbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>UDF4</td><td>&nbsp;&nbsp;<asp:Label ID="udf4Lbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>UDF5</td><td>&nbsp;&nbsp;<asp:Label ID="udf5Lbl" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td>Payment ID</td><td>&nbsp;&nbsp;<asp:Label ID="paymentidLbl" runat="server"></asp:Label></td>
							</tr>
                            <tr>
								<td>Token Number</td><td>&nbsp;&nbsp;<asp:Label ID="tokenNumber" runat="server"></asp:Label></td>
							</tr>
							</table>
						</td>
					</tr>
				</table>
			<br>
            <p class="no-re-warn return-flkp succ"><a class="btn btn-danger" onclick="document.getElementById('formACS').submit();" target="_parent">Click here</a> for go to Home page </p>
        </div>
</form>

</html>
