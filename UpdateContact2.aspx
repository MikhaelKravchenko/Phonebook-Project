<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2.Master" CodeBehind="UpdateContact2.aspx.cs" Inherits="PhoneBook2.UpdateContact2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">

        <table ID="tblsearch" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblFirstName" runat="server" Text="First Name"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength ="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="ReqularFieldValidator1" ControlToValidate ="txtFirstName" runat ="server" ForeColor="Red"  ErrorMessage ="Please enter a First Name" ></asp:RequiredFieldValidator>               
            </td>        
        </tr>
       <tr>
           <td style="text-align:left"><asp:Label ID="lblLastName" runat="server" Text="Last Name" ></asp:Label></td>
           <td>
               <asp:TextBox ID="txtLastName" runat="server" MaxLength ="20" ></asp:TextBox>   
               <asp:RequiredFieldValidator ID ="ReqularFieldValidator2" ControlToValidate ="txtLastName" runat ="server" ForeColor="Red"  ErrorMessage ="Please enter a Last Name" ></asp:RequiredFieldValidator>               
               </td>
           </tr>
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"  ></asp:Label></td>   
            <td>
                <asp:TextBox ID="txtDateofBirth" runat="server" MaxLength ="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="ReqularFieldValidator3" ControlToValidate ="txtDateOfBirth" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a Date of Birth" ></asp:RequiredFieldValidator>               
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
                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="Images/update%20contact%20info.jpg"  OnClick="btnUpdate_Click"/>
            </td>          
            </tr>
            </table>
  
    
    
    
    
    
       
 
  <table>
       <tr>
           <td>
               <h3> 
            Phones:
        </h3>

               <asp:GridView CellPadding="5" ID="grvPhone" runat="server" AutoGenerateColumns="False" OnSorting="grvPhone_Sorting" 
                   OnRowCommand="grvPhone_RowCommand" OnRowDataBound ="grvPhone_RowDataBound" OnRowDeleting="grvPhone_RowDeleting"
                   EmptyDataText="No matches were found" AllowSorting="true" AllowPaging="true" GridLines="None" PageSize ="3" OnPageIndexChanging="grvPhone_PageIndexChanging"
                   BackColor="#ccccff"><HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#032ba4"  />

<HeaderStyle />

           <columns>
               
                <asp:HyperLinkField Text="Details" HeaderText="Information" DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" />  
                <asp:BoundField datafield="ID" HeaderText="ID"  SortExpression="ID" HeaderStyle-HorizontalAlign="Left" Visible="false"/>    
                <asp:BoundField datafield="PHONE_NUMBER" HeaderText="PHONE NUMBER"  SortExpression="PHONE_NUMBER" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField datafield="PHONE_TYPE" HeaderText="PHONE TYPE"    SortExpression="PHONE_TYPE" HeaderStyle-HorizontalAlign="Left" />               
                <asp:BoundField datafield="update_by" HeaderText="UPDATE BY"  SortExpression="update_by" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="UPDATE_DT" HeaderText="UPDATE DATE"  SortExpression="UPDATE_DT" HeaderStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Action" ShowHeader="False">               
                    <ItemTemplate>                        
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>                                              
                    </ItemTemplate>
                </asp:TemplateField>
                   </columns>
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
           </td>
       </tr>
   </table>

   
    <table>
       <tr>
           <td>
               <h3> 
            Addresses:
        </h3>

               <asp:GridView CellPadding="5" ID="grvAddress" runat="server" AutoGenerateColumns="False" OnSorting="grvAddress_Sorting" 
                   OnRowCommand="grvAddress_RowCommand" OnRowDataBound ="grvAddress_RowDataBound" OnRowDeleting="grvAddress_RowDeleting"
                   EmptyDataText="No matches were found" AllowSorting="true" AllowPaging="true" GridLines="None" PageSize ="5" OnPageIndexChanging="grvAddress_PageIndexChanging"
                   BackColor="#ccccff"><HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#032ba4"  />

<HeaderStyle />

           <columns>
               
                <asp:HyperLinkField Text="Details" HeaderText="Information" DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" />      
                <asp:BoundField datafield="ID" HeaderText="ID"  SortExpression="ID" HeaderStyle-HorizontalAlign="Left" Visible="false"/> 
                <asp:BoundField datafield="ADDRESS_TYPE" HeaderText="ADDRESS TYPE"  SortExpression="ADDRESS_TYPE" HeaderStyle-HorizontalAlign="Left"/> 
                <asp:BoundField datafield="ADDRESS_1" HeaderText="ADDRESS 1"  SortExpression="ADDRESS_1" HeaderStyle-HorizontalAlign="Left"/> 
                <asp:BoundField datafield="ADDRESS_2" HeaderText="ADDRESS 2"  SortExpression="ADDRESS_2" HeaderStyle-HorizontalAlign="Left"/>               
                <asp:BoundField datafield="STATE_ID" HeaderText="STATE"  SortExpression="STATE_ID" HeaderStyle-HorizontalAlign="Left"/>          
                <asp:BoundField datafield="CITY" HeaderText="CITY"  SortExpression="CITY" HeaderStyle-HorizontalAlign="Left"/> 
                <asp:BoundField datafield="ZIP" HeaderText="ZIP"  SortExpression="ZIP" HeaderStyle-HorizontalAlign="Left"/>                   
                <asp:BoundField datafield="update_by" HeaderText="UPDATE BY"  SortExpression="update_by" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="UPDATE_DT" HeaderText="UPDATE DATE"  SortExpression="UPDATE_DT" HeaderStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Action" ShowHeader="False">               
                    <ItemTemplate>                        
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>                                              
                    </ItemTemplate>
                </asp:TemplateField>
                   </columns>
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
           </td>
       </tr>
   </table>

    
<table>
       <tr>
           <td>
               <h3> 
            Emails:
        </h3>


               <asp:GridView CellPadding="5" ID="grvEmails" runat="server" AutoGenerateColumns="False" OnSorting="grvEmails_Sorting" 
                   OnRowCommand="grvEmails_RowCommand" OnRowDataBound ="grvEmails_RowDataBound" OnRowDeleting="grvEmails_RowDeleting"
                   EmptyDataText="No matches were found" AllowSorting="true" AllowPaging="true" GridLines="None" PageSize ="5" OnPageIndexChanging="grvEmails_PageIndexChanging"
                   BackColor="#ccccff"><HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#032ba4"  />

<HeaderStyle />

           <columns>
               
                <asp:HyperLinkField Text="Details" HeaderText="Information" DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" />      
                <asp:BoundField datafield="EMAIL_ADDRESS" HeaderText="EMAIL ADDRESS"  SortExpression="EMAIL_ADDRESS" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField datafield="EMAIL_TYPE" HeaderText="EMAIL TYPE"    SortExpression="EMAIL_TYPE" HeaderStyle-HorizontalAlign="Left" />               
                <asp:BoundField datafield="update_by" HeaderText="UPDATE BY"  SortExpression="update_by" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="UPDATE_DT" HeaderText="UPDATE DATE"  SortExpression="UPDATE_DT" HeaderStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="Action" ShowHeader="False">               
                    <ItemTemplate>                        
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>                                              
                    </ItemTemplate>
                </asp:TemplateField>
                   </columns>
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
           </td>
       </tr>
   </table>













 </asp:Content>            


