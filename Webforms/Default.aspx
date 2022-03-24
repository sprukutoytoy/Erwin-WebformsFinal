<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Webforms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <input type="text" runat="server" id="inputName" name="CustomerName" placeholder="Customer Name" maxlength="100" required="required" />
    <input type="text" runat="server" id="inputPhone" name="CustomerPhone" placeholder="Phone Number" maxlength="10" />
    <asp:Button ID="BtnAddCustomer" runat="server" OnClick="BtnAddCustomer_Click" Text="Add Customer" />
    <div class="row">
        <asp:GridView runat="server" ID="CustomersGrid"
            ItemType="Webforms.Models.Customer" DataKeyNames="CustomerID"
            SelectMethod="GetCustomers" UpdateMethod="CustomersGrid_UpdateItem" DeleteMethod="CustomersGrid_DeleteItem"
            AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="ACTION">
                    <ItemTemplate>
                        <asp:Button runat="server" Text='Update' CommandName="Edit" UseSubmitBehavior="false" />
                        <asp:Button runat="server" Text='Delete' CommandName="Delete" UseSubmitBehavior="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button runat="server"  Text='Save' CommandName="Update" UseSubmitBehavior="false" />
                        <asp:Button runat="server" Text='Cancel' CommandName="Cancel" UseSubmitBehavior="false" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CUSTOMER NAME">
                    <ItemTemplate>
                        <asp:Label ID="LblName" runat="server" Text="<%# Item.Name %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtEditName" runat="server" Text="<%# BindItem.Name %>" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvEditName" runat="server" ControlToValidate="TxtEditName"
                            ErrorMessage="Error"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PHONE NUMBER">
                    <ItemTemplate>
                        <asp:Label ID="LblPhone" runat="server" Text="<%# Item.Phone %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtEditPhone" runat="server" Text="<%# BindItem.Phone %>" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RfvEditPhone"
                            ControlToValidate="TxtEditPhone" runat="server"
                            ErrorMessage="Error"
                            ValidationExpression="\d+">
                        </asp:RegularExpressionValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <a href="/ItemList.aspx?CustomerId=<%#: Item.CustomerID %>" usesubmitbehavior="false">List Item</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
</asp:Content>
