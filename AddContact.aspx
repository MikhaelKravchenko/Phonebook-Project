<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2.Master" CodeBehind="AddContact.aspx.cs" Inherits="PhoneBook2.AddContact" %>



<asp:Content ContentPlaceHolderID="cphMainContent" runat ="server" >
    <div>
    <asp:Label id ="lbluserid" runat="server" ></asp:Label>

         <table ID="tblsearch" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblFirstName" runat="server" Text="First Name"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength ="20"></asp:TextBox>
            </td>        
        </tr>
       <tr>
           <td style="text-align:left"><asp:Label ID="lblLastName" runat="server" Text="Last Name" ></asp:Label></td>
           <td>
               <asp:TextBox ID="txtLastName" runat="server" MaxLength ="20" ></asp:TextBox>
               </td>
           </tr>
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"  ></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDateofBirth" runat="server" MaxLength ="25"></asp:TextBox>
            </td>
           </tr>
        <tr>
            <td> <asp:Label ID="lblPersonType" runat="server" Text="Person Type"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="DDLPersonType" runat="server" >    
                </asp:DropDownList>
            </td>
           </tr>

        </table>

        <table ID="tblbutton" runat="server">
            <tr>
                <td>
                    <asp:Label ID ="lblErrMsg" ForeColor="Red" runat="server" ></asp:Label>
                </td>
            </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="Images/create%20new%20contact.png" OnClick="btnAdd_Click"/>

            </td>
           
            </tr>
            </table>
     
      
    </div>
</asp:Content>
