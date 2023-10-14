<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_14.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Titulo</h1>
    <asp:Button ID="Button1" runat="server" OnClick="btnAceptar" Text="Button" />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%  
            foreach (Dominio.Articulos item in listaArticulos)
            {
%>
        <div class="col">
            <div class="card">
                 <img src="<%:item.Imagen[0]%>" class="d-block w-100" alt="..." onerror="this.onerror=null;this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';">             
                <div class="card-body">
                    <h5 class="card-title"><%: item.Nombre %></h5>
                    <p class="card-text"><%: item.Descripcion %></p>
                </div>
            </div>
        </div>
    
    <% } %>
        </div>
</asp:Content>
