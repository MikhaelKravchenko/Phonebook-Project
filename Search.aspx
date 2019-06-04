<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site2.Master" CodeBehind="Search.aspx.cs" Inherits="PhoneBook2.Search" %>

<asp:Content ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label  runat="server" id ="lblHeader" Text ="Search Menu:" Font-Bold="true" ForeColor="Blue" Font-Size="medium">

    </asp:Label>

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
                <asp:TextBox ID="txtDateofBirth" runat="server"  CausesValidation="true" MaxLength ="10"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDateofBirth" 
                 ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"  Display="Dynamic" SetFocusOnError="true"
                 ValidationGroup="Group1" Operator="DataTypeCheck" Type="Date" ></asp:CompareValidator>                    
                
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
    <td>
        <asp:Label ID="lblErrorMsg" runat="server" Text="Invalid Date of Birth" ForeColor="Red" Visible="false"></asp:Label>
    </td>
       
    <table ID="tblbutton" runat="server">
        <tr>
            <td>
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Images/search-button.png" OnClick="btnSearch_Click" /></td>
                             
            <td>
                &nbsp;<asp:ImageButton ID="btnAdd" runat="server"  ImageUrl="Images/ADD%20CONTACT.png" OnClick="btnAdd_Click"/>
            </td>
           
       
           
        </tr>
    </table>


   <table>
       <tr>
           <td>
               <asp:GridView CellPadding="5" ID="grvSearch" runat="server" AutoGenerateColumns="False" OnSorting="grvSearch_Sorting" 
                   OnRowCommand="grvSearch_RowCommand" OnRowDataBound ="grvSearch_RowDataBound" OnRowDeleting="grvSearch_RowDeleting"
                   EmptyDataText="No matches were found" AllowSorting="true" AllowPaging="true" GridLines="None" PageSize ="5" OnPageIndexChanging = "grvSearch_PageIndexChanging"
                   BackColor="#ccccff"><HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#032ba4"  />

<HeaderStyle />

           <columns>
               
                <asp:HyperLinkField Text="Details" HeaderText="Information" DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" />      
                <asp:BoundField datafield="FIRST_NM" HeaderText="FIRST NAME"  SortExpression="FIRST_NM" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField datafield="LAST_NM" HeaderText="LAST NAME"    SortExpression="LAST_NM" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="DOB" HeaderText="DOB" SortExpression ="DOB" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="PERSON_TYPE" HeaderText="PERSON TYPE"  SortExpression="PERSON_TYPE" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField datafield="LOGIN" HeaderText="LOGIN"  SortExpression="LOGIN" HeaderStyle-HorizontalAlign="Left" />
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


<asp:Content ID="Content1" runat="server" contentplaceholderid="head">  
</asp:Content>





