<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_14.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #content-container {
            margin-left: 15%;
            margin-right: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container">
        <h1>Lista de productos</h1>
       
        <br />

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <a style="text-decoration:none" href="Detalle.aspx?id=<%# ((TPWeb_equipo_14.Articulos)Container.DataItem).ID %>">                         
                        <div class="card mw-100">
                            <div class="card-body">
                                <%# cargarImagen(((TPWeb_equipo_14.Articulos)Container.DataItem)?.Imagen?.LastOrDefault()?.ToString()) %>
                                <asp:Image CssClass="card-img-top" ID="imgArticulo" runat="server" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                                <h4 class="card-title"><%# ((TPWeb_equipo_14.Articulos)Container.DataItem).Nombre %></h4>
                                <p class="card-text"><%# ((TPWeb_equipo_14.Articulos)Container.DataItem).Descripcion %></p>
                                <p class="card-text fw-semibold text-success display-6">$<%# Math.Round(((TPWeb_equipo_14.Articulos)Container.DataItem).Precio, 2) %></p>
                                <a href="Detalle.aspx?id=<%# ((TPWeb_equipo_14.Articulos)Container.DataItem).ID %>" class="btn btn-outline-primary w-100 mb-1">Ver más</a>
                                <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" OnClick="btnAgregar_Click" CommandArgument='<%# ((TPWeb_equipo_14.Articulos)Container.DataItem).ID.ToString() %>' />

                            </div>
                        </div>
                             </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
