<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Settings.ascx.cs" Inherits="DotNetNuke.Modules.DNNReferralModule.Settings" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

<table cellspacing="0" cellpadding="2" border="0">
    <tr>
        <td class="SubHead">
            <dnn:label id="lblReferralCode" runat="server" controlname="txtReferralCode" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtReferralCode" runat="server" Width="120" MaxLength="30" CssClass="NormalTextBox" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblMode" runat="server" controlname="ddlMode" suffix=":" />
        </td>
        <td>
            <asp:DropDownList ID="ddlMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMode_SelectedIndexChanged" >
                <asp:ListItem resourcekey="liTopModules" Value="TopModules"></asp:ListItem>
                <asp:ListItem resourcekey="liTopSkins" Value="TopSkins"></asp:ListItem>
                <asp:ListItem resourcekey="liMyProducts" Value="MyProducts"></asp:ListItem>
                <asp:ListItem resourcekey="liSearchResults" Value="SearchResults"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr runat="server" id="trVendorId">
        <td class="SubHead">
            <dnn:label id="lblVendorId" runat="server" controlname="txtVendorId" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtVendorId" runat="server" Width="60" MaxLength="10" CssClass="NormalTextBox" />&nbsp;
            <asp:CompareValidator ID="Comparevalidator1" runat="server" ErrorMessage="Not a valid whole number!" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtVendorId" Display="Dynamic" />
        </td>
    </tr>
    <tr runat="server" id="trSearchParameter">
        <td class="SubHead">
            <dnn:label id="lblSearchParameter" runat="server" controlname="txtSearch Parameter" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtSearchParameter" runat="server" Width="120" CssClass="NormalTextBox" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblSortOrder" runat="server" controlname="ddlSortOrder" suffix=":" />
        </td>
        <td>
            <asp:DropDownList ID="ddlSortOrder" runat="server">
                <asp:ListItem resourcekey="liRelevance" Value="Relevance"></asp:ListItem>
                <asp:ListItem resourcekey="liPublishedDateDesc" Value="PublishedDateDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liUpdatedDateDesc" Value="UpdatedDateDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liReviewDesc" Value="ReviewDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liSalesUnitsDesc" Value="SalesUnitsDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liSalesRevenueDesc" Value="SalesRevenueDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liRecentSalesUnitsDesc" Value="RecentSalesUnitsDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liRecentSalesRevenueDesc" Value="RecentSalesRevenueDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liNameAsc" Value="NameAsc"></asp:ListItem>
                <asp:ListItem resourcekey="liNameDes" Value="NameDesc"></asp:ListItem>
                <asp:ListItem resourcekey="liPriceAsc" Value="PriceAsc"></asp:ListItem>
                <asp:ListItem resourcekey="liPriceDes" Value="PriceDesc"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblNumberOfResults" runat="server" controlname="txtNumberOfResults" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtNumberOfResults" runat="server" Width="60" MaxLength="10" CssClass="NormalTextBox" />&nbsp;
            <asp:CompareValidator runat="server" ErrorMessage="Not a valid whole number!" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtNumberOfResults" Display="Dynamic" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtNumberOfResults" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblPrimaryTemplate" runat="server" controlname="txtPrimaryTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtPrimaryTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtPrimaryTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblRowTemplate" runat="server" controlname="txtRowTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtRowTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtRowTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblItemTemplate" runat="server" controlname="txtItemTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtItemTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtItemTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblNoResultsTemplate" runat="server" controlname="txtNoResultsTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtNoResultsTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required!" ControlToValidate="txtNoResultsTemplate" Display="Dynamic" />
        </td>
    </tr>
</table>