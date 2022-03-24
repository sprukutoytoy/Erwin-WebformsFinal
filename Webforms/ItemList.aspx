<%@ Page Title="Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="Webforms.ItemList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <input type="text" runat="server" id="inputTitle" name="ItemTitle" placeholder="Title" maxlength="100" required="required" />
    <input type="number" runat="server" id="inputWeight" name="ItemWeight" placeholder="Weight" required="required" min="0" step=".01" />
    <asp:Button ID="BtnAddItem" runat="server" OnClick="BtnAddItem_Click" Text="Add Item" />
    <hr />
    <asp:GridView runat="server" ID="ItemGrid"
                ItemType="Webforms.Models.Item" DataKeyNames="ItemID"
                SelectMethod="GetItems" UpdateMethod="ItemGrid_UpdateItem" DeleteMethod="ItemGrid_DeleteItem"
                AutoGenerateColumns="false" OnRowDataBound="ItemGrid_RowDataBound" OnRowCreated="ItemGrid_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="PARCEL TITLE">
                        <ItemTemplate>
                            <asp:Label ID="LblTitle" runat="server" Text="<%# Item.Title %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtEditTitle" runat="server" Text="<%# BindItem.Title %>" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RfvEditTitle" runat="server" ControlToValidate="TxtEditTitle"
                                ErrorMessage="Error"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PARCEL WEIGHT">
                        <ItemTemplate>
                            <asp:Label ID="LblWeight" runat="server" Text="<%# Item.Weight %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtEditWeight" runat="server" Text="<%# BindItem.Weight %>"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RfvEditWeight" runat="server" ControlToValidate="TxtEditWeight"
                                ErrorMessage="Error"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate>
                            <asp:Button runat="server"  Text='Update' CommandName="Edit" UseSubmitBehavior="false" />
                            <asp:Button runat="server" Text='Delete' CommandName="Delete" UseSubmitBehavior="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button runat="server"  Text='Save' CommandName="Update" UseSubmitBehavior="false" />
                            <asp:Button runat="server" Text='Cancel' CommandName="Cancel" UseSubmitBehavior="false" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <dl>
                <dd>TOTAL WEIGHT</dd>
                <dt><asp:Label ID="tot" runat="server" /></dt>
                <dd>TOTAL COST</dd>
                <dt><asp:Label ID="Label1" runat="server" /></dt>
                <dd>CLASSIFICATION</dd>
                <dt><asp:Label ID="Label2" runat="server" /></dt>
            </dl>

</asp:Content>
