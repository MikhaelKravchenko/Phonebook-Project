<%@ Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateContact.aspx.cs" Inherits="PhoneBook2.UpdateContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">

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
                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="Images/create%20new%20contact.png" OnClick="btn"/>

            </td>
           
            </tr>
            </table>
     

</asp:Content>

 
  
             


