<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Settings.ascx.cs" Inherits="DotNetNuke.Modules.DNNReferralModule.Settings" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

<table cellspacing="0" cellpadding="2" border="0">
    <tr>
        <td>
            <div style="width: 200px">&nbsp;</div>
        </td>
        <td>
            
        </td>
    </tr>
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
                <asp:ListItem resourcekey="liDynamicSearchResults" Value="DynamicSearchResults"></asp:ListItem>
                <asp:ListItem resourcekey="liStaticSearchResults" Value="StaticSearchResults"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr runat="server" id="trSearchParameter">
        <td class="SubHead">
            <dnn:label id="lblSearchParameter" runat="server" controlname="txtSearchParameter" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtSearchParameter" runat="server" Width="120" CssClass="NormalTextBox" />
        </td>
    </tr>
    <tr runat="server" id="trEnableFallBackMode">
        <td class="SubHead">
            <dnn:label id="lblEnableFallBackMode" runat="server" controlname="chkEnableFallBackMode" suffix=":" />
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkEnableFallBackMode" AutoPostBack="True" OnCheckedChanged="chkEnableFallBackMode_CheckedChanged"/>
        </td>
    </tr>
    <tr runat="server" id="trSearchFallBack">
        <td class="SubHead">
            <dnn:label id="lblFallBackMode" runat="server" controlname="ddlFallBackMode" suffix=":" />
        </td>
        <td>
            <asp:DropDownList ID="ddlFallBackMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFallBackMode_SelectedIndexChanged" >
                <asp:ListItem resourcekey="liTopModules" Value="TopModules"></asp:ListItem>
                <asp:ListItem resourcekey="liTopSkins" Value="TopSkins"></asp:ListItem>
                <asp:ListItem resourcekey="liMyProducts" Value="MyProducts"></asp:ListItem>
                <asp:ListItem resourcekey="liStaticSearchResults" Value="StaticSearchResults"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr runat="server" id="trFallBackSortOrder">
        <td class="SubHead">
            <dnn:label id="lblFallBackSortOrder" runat="server" controlname="ddlFallBackSortOrder" suffix=":" />
        </td>
        <td>
            <asp:DropDownList ID="ddlFallBackSortOrder" runat="server">
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
    <tr runat="server" id="trVendorId">
        <td class="SubHead">
            <dnn:label id="lblVendorId" runat="server" controlname="txtVendorId" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtVendorId" runat="server" Width="60" MaxLength="10" CssClass="NormalTextBox" />&nbsp;
            <asp:CompareValidator ID="cvVendorId" runat="server" meta:resourcekey="NotAValidNumber" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtVendorId" Display="Dynamic" />
        </td>
    </tr>
    <tr runat="server" id="trStaticSearch">
        <td class="SubHead">
            <dnn:label id="lblStaticSearch" runat="server" controlname="txtStaticSearch" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtStaticSearch" runat="server" Width="120" CssClass="NormalTextBox" />
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
            <asp:CompareValidator ID="cvNumberOfResults" runat="server" meta:resourcekey="NotAValidNumber" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtNumberOfResults" Display="Dynamic" />&nbsp;
            <asp:RequiredFieldValidator ID="rfvNumberOfResults" runat="server" meta:resourcekey="Required" ControlToValidate="txtNumberOfResults" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblEnableCache" runat="server" controlname="chkEnableCache" suffix=":" />
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkEnableCache" AutoPostBack="True" OnCheckedChanged="chkEnableCache_CheckedChanged"/>
        </td>
    </tr>
    <tr runat="server" id="trCacheDuration">
        <td class="SubHead">
            <dnn:label id="lblCacheDuration" runat="server" controlname="txtCacheDuration" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtCacheDuration" runat="server" Width="120" CssClass="NormalTextBox" />&nbsp;
            <asp:CompareValidator ID="cvCacheDuration" runat="server" meta:resourcekey="NotAValidNumber" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtCacheDuration" Display="Dynamic" />&nbsp;
        </td>
    </tr>
    <tr runat="server" id="trClearCache">
        <td class="SubHead">
            <dnn:label id="lblClearCache" runat="server" controlname="btnClearCache" suffix=":" />
        </td>
        <td>
            <asp:Button ID="btnClearCache" runat="server" OnClick="btnClearCache_Click" resourcekey="btnClearCache.Text" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblPrimaryTemplate" runat="server" controlname="txtPrimaryTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtPrimaryTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator ID="rfvPrimaryTemplate" runat="server" meta:resourcekey="NotAValidNumber" ControlToValidate="txtPrimaryTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblRowTemplate" runat="server" controlname="txtRowTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtRowTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator ID="rfvRowTemplate" runat="server" meta:resourcekey="NotAValidNumber" ControlToValidate="txtRowTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblItemTemplate" runat="server" controlname="txtItemTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtItemTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator ID="rfvItemTemplate" runat="server" meta:resourcekey="NotAValidNumber" ControlToValidate="txtItemTemplate" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:label id="lblNoResultsTemplate" runat="server" controlname="txtNoResultsTemplate" suffix=":" />
        </td>
        <td>
            <asp:TextBox ID="txtNoResultsTemplate" runat="server" Width="400" Height="200" CssClass="NormalTextBox" TextMode="MultiLine" />&nbsp;
            <asp:RequiredFieldValidator ID="rfvNoResultsTemplate" runat="server" meta:resourcekey="NotAValidNumber" ControlToValidate="txtNoResultsTemplate" Display="Dynamic" />
        </td>
    </tr>
</table>