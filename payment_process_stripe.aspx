<%@ Page Language="VB" AutoEventWireup="false" CodeFile="payment_process_stripe.aspx.vb" Inherits="payment_process_stripe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="<%= strResponseSuccessURL %>" method="post">

        No of Credit :
        <asp:Label ID="LABEL_NoOfCredit" runat="server" Text=""></asp:Label>
        <br /><br />
        Total Cost :
        <asp:Label ID="LABEL_TotalCost" runat="server" Text=""></asp:Label>
        <br /><br />
        Name :
        <asp:Label ID="LABEL_Name" runat="server" Text=""></asp:Label>
        <br /><br />

        <script
            src="https://checkout.stripe.com/checkout.js" class="stripe-button"
            data-key="<%= strDataKey %>"
            data-amount="<%= strTotalAmount %>"
            data-name="<%= strUserName %>"
            data-description="<%= strDataDescription %>"
            data-image="https://stripe.com/img/documentation/checkout/marketplace.png"
            data-locale="auto"
            data-currency="gbp"
            data-zip-code="true">
        </script>
    </form>
</body>
</html>
