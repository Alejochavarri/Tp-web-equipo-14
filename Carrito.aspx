<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWeb_equipo_14.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Mi Carrito</h1>
    <table class="table">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Descripcion</th>
                <th>Precio</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCarrito" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Descripcion") %></td>
                        <td><%# Eval("Precio", "{0:C}") %></td>
                        <td>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' OnClick="btnEliminar_Click" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td class="display-6">Total</td>
                <td></td>
                <td colspan="2" class="display-6"><%: this.ObtenerTotalCarrito().ToString() %></td> 
            </tr>
        </tbody>
    </table>
<asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary" OnClick="btnPagar_Click" />
</asp:Content>
