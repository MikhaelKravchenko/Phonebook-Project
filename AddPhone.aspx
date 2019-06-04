<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2.Master" CodeBehind="AddPhone.aspx.cs" Inherits="PhoneBook2.AddPhone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat ="server" >
    <div>
    <asp:Label id ="lbluserid" runat="server" ></asp:Label>

        <table ID="tblphone" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength ="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="ReqularFieldValidator1" ControlToValidate ="txtPhoneNumber" runat ="server" ForeColor="Red"  ErrorMessage ="Please enter a Phone Number" ValidationGroup="CreatePhone"></asp:RequiredFieldValidator>               
            </td>        
        </tr>
        <tr>
            <td> <asp:Label ID="lblPhoneType" runat="server" Text="Phone Type"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="DDLPhoneType" runat="server" ValidationGroup="CreatePhone">    
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
                <asp:ImageButton ID="btnAddPhone" runat="server" ImageUrl="Images/create%20phone%20number.png" OnClick="btnAdd_Phone"/>
            </td>          
            </tr>
            </table>
    </div>







     <div>   

        <table ID="Table1" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="Label2" runat="server" Text="Phone Number"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtPhoneUpdate" runat="server" MaxLength ="20" ></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" ControlToValidate ="txtPhoneUpdate" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a Phone Number" ValidationGroup="UpdatePhone"></asp:RequiredFieldValidator>               
            </td>        
        </tr>
        <tr>
            <td> <asp:Label ID="Label3" runat="server" Text="Phone Type"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlPhoneTypeEdit" runat="server" ValidationGroup="UpdatePhone" >    
                </asp:DropDownList>
            </td>
           </tr>
        </table>
        <table ID="Table2" runat="server">
            <tr>
                <td>
                    <asp:Label ID ="lblErrMsg2" ForeColor="Red" runat="server" ></asp:Label>
                </td>
            </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnUpdatePhone" runat="server" ImageUrl="Images/Update%20Phone%20Number.png" OnClick="btnUpdate_Phone" ValidationGroup="CreatePhone"/>
            </td>          
            </tr>
            </table>
    </div>





     <div>   

        <table ID="Table3" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="lblAddress_1" runat="server" Text="Address 1"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtAddress_1" runat="server" MaxLength ="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator2" ControlToValidate ="txtAddress_1" runat ="server" ForeColor="Red" ErrorMessage ="Please enter an Address" ValidationGroup="CreateAddress"></asp:RequiredFieldValidator>               
            </td>   
            </tr>     
         <tr>
             <td style="text-align:left"> <asp:Label ID="lblAddress_2" runat="server" Text="Address 2"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtAddress_2" runat="server" MaxLength ="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator3" ControlToValidate ="txtAddress_2" runat ="server" ForeColor="Red" ErrorMessage ="Please enter an Address" ValidationGroup="CreateAddress"></asp:RequiredFieldValidator>               
            </td>  
        </tr>
            <tr>
             <td style="text-align:left"> <asp:Label ID="City" runat="server" Text="City"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtCity" runat="server" MaxLength ="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator6" ControlToValidate ="txtCity" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a City" ValidationGroup="CreateAddress"></asp:RequiredFieldValidator>               
            </td>  
        </tr>        
            <tr>
             <td style="text-align:left"> <asp:Label ID="Zip" runat="server" Text="Zip"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtZip" runat="server" MaxLength ="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator8" ControlToValidate ="txtZip" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a Zip code" ValidationGroup="CreateAddress"></asp:RequiredFieldValidator>               
            </td>  
        </tr>
        <tr>
            <td> <asp:Label ID="Label4" runat="server" Text="State"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="DDLState" runat="server" ValidationGroup="CreateAddress" >    
                </asp:DropDownList>
            </td>
           </tr>
         <tr>
            <td> <asp:Label ID="Label5" runat="server" Text="Address Type"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="DDLAddressType" runat="server" ValidationGroup="CreateAddress" >    
                </asp:DropDownList>
            </td>
           </tr>
        </table> 
        <table ID="Table4" runat="server">
            <tr>
                <td>
                    <asp:Label ID ="Label6" ForeColor="Red" runat="server" ></asp:Label>
                </td>
            </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnCreateAddress" runat="server" ImageUrl="Images/Create%20address.png" OnClick="btnAdd_Address" ValidationGroup="CreateAddress"/>
            </td>          
            </tr>
            </table>
    </div>



     <div>   

        <table ID="UpdateAddress" runat="server" Width ="500">
        <tr>
            <td style="text-align:left"> <asp:Label ID="Label7" runat="server" Text="Address 1"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtAddress1Update" runat="server" MaxLength ="40" style="margin-bottom: 0px"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator4" ControlToValidate ="txtAddress1Update" runat ="server" ForeColor="Red" ErrorMessage ="Please enter an Address" ValidationGroup="UpdateAddress"></asp:RequiredFieldValidator>               
            </td>        
        </tr>
         <tr>
             <td style="text-align:left"> <asp:Label ID="Label8" runat="server" Text="Address 2"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtAddress2Update" runat="server" MaxLength ="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator5" ControlToValidate ="txtAddress2Update" runat ="server" ForeColor="Red" ErrorMessage ="Please enter an Address" ValidationGroup="UpdateAddress" ></asp:RequiredFieldValidator>               
            </td>  
        </tr>
            <tr>
             <td style="text-align:left"> <asp:Label ID="Label9" runat="server" Text="City"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtCityUpdate" runat="server" MaxLength ="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator7" ControlToValidate ="txtCityUpdate" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a City" ValidationGroup="UpdateAddress"></asp:RequiredFieldValidator>               
            </td>  
        </tr>
             <tr>
             <td style="text-align:left"> <asp:Label ID="Label10" runat="server" Text="Zip"  ></asp:Label></td>
            <td>    
                <asp:TextBox ID="txtZipUpdate" runat="server" MaxLength ="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator9" ControlToValidate ="txtZipUpdate" runat ="server" ForeColor="Red" ErrorMessage ="Please enter a Zip code" ValidationGroup="UpdateAddress"></asp:RequiredFieldValidator>               
            </td>  
        </tr>
            <tr>
            <td> <asp:Label ID="Label1" runat="server" Text="State"  ></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="UpdateAddress" >    
                </asp:DropDownList>
            </td>                       
            </tr>
            <tr>           
            <td> <asp:Label ID="Label11" runat="server" Text="Address Type"  ></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAddressTypeEdit" runat="server" ValidationGroup="UpdateAddress" >    
                </asp:DropDownList>
            </td>
           </tr>
        </table>
        <table ID="Table6" runat="server">
            <tr>
                <td>
                    <asp:Label ID ="Label12" ForeColor="Red" runat="server" ></asp:Label>
                </td>
            </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnUpdateAddress" runat="server" ImageUrl="Images/update%20address.png" OnClick="btnUpdate_Address" ValidationGroup="UpdateAddress"/>
            </td>          
            </tr>
            </table>
    </div>




 </asp:Content>   