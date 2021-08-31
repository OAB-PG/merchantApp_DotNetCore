<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="merchantApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
                        <div class="jumbotron">
                        <h2>Merchant Sample Application</h2>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <h2></h2>
                            <p>Bank Hosted Transaction<a class="btn btn-default" href="/bankhosted/bankHstedPaymentInfoDetails.aspx">Bank Hosted Transaction &raquo;</a></p>
                            <p>Merchant Hosted VBV Transaction<a class="btn btn-default" href="/merchanthstcvbv/paymentInfovbvDetails.aspx">Merchant Hosted VBV &raquo;</a></p>
                             <p>Inquiry and Void Service Transaction <a class="btn btn-default" href="/inquiryservice/paymentInquiryDetails.aspx">Inquiry And Void Service&raquo;</a></p>
                        </div>
                    </div>
                   </div>

</asp:Content>