<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_14.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row g-3">

        <div class="col" style="width: 50%">
            <div id="carouselExample" class="carousel carousel-dark slide">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                      <img src="<%:item.Imagen[0]%>" class="d-block w-100" alt="..." onerror="this.onerror=null;this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';">                     
                    </div>
                    <!--foreach-->
                    <div class="carousel-item">
                        <img src="<%:listaArticulos[3].Imagen[0]%>" class="d-block w-100" alt="...">
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>
        <div class="col align-self-center" style="padding: 20px">
            <h3 style="padding: 10px;">Id : <%:item.ID %></h3>
            <h3 style="padding: 10px;">Codigo : <%:item.Codigo %></h3>
            <h3 style="padding: 10px;">Nombre : <%:item.Nombre %></h3>
            <h3 style="padding: 10px;">Descripcion : <%:item.Descripcion %></h3>
            <h3 style="padding: 10px;">Marca : <%:item.Marca %></h3>
            <h3 style="padding: 10px;">Categoria : <%:item.Categoria %></h3>
            <h3 style="padding: 10px;">Precio : <%:item.Precio %></h3>
            <asp:Button ID="btnVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="btnVolver_Click" />
            <asp:Button ID="btnAgregar" runat="server" class="btn btn-outline-primary" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>

    </div>
</asp:Content>
