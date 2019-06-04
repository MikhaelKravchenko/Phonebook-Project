<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2.Master" CodeBehind="Default.aspx.cs" Inherits="PhoneBook2.Default" %>


<asp:Content ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="header_title" style="margin-left: auto; margin-right: auto; text-align: center;" >
    <asp:Label ID="lblTitle" runat="server"  Visible="true"  Text=" Welcome to the HRA Phone Book Directory! Here you will find the contact information of the HRA staff. Please handle the contents carefully as they are case sensitive! Thank you."  ></asp:Label>
</div>
   <br/>
        <asp:Table ID="tblLogin" runat="server" Width="300">
        <asp:TableRow>
            <asp:TableCell> <asp:Label ID="lblUserName" runat="server" Text="User name"  ></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtUserName" runat="server" MaxLength ="25"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Required)" ControlToValidate="txtUserName" ForeColor ="Red" ></asp:RequiredFieldValidator>
            </asp:TableCell>
           </asp:TableRow>
            
          

          <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblPassWord" runat="server" Text="Password" ></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength ="25" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Required)" ControlToValidate="txtPassword" ForeColor ="Red" ></asp:RequiredFieldValidator>

            </asp:TableCell>
           
        </asp:TableRow>
    </asp:Table>
    <asp:Table runat="server" ID ="tblLogin2" Width="300" >
        <asp:TableRow>
            <asp:TableCell >
            <asp:Label  runat="server" ID ="lblErrMsg" ForeColor="Red" Visible="false" ></asp:Label>
                      </asp:TableCell>

        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table2" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="Images/login.png" OnClick="btnLogin_Click" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>