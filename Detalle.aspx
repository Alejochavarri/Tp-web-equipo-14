<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_14.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div style="background-color:#e9ecef"">  
    <div class="row g-3" style="margin-top:0px;margin:0px; background-color:#e9ecef">

        <div class="col" style="width: 50%">
            <div id="carouselExample" class="carousel carousel-dark slide">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="<%:item.Imagen[0]%>" class="d-block w-100 " alt="..." onerror="this.onerror=null;this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';" style="width: 450px; height: 450px;">
                    </div>
                    <%foreach (TPWeb_equipo_14.Imagen Img in listaImagenes)
                        {
                            if (item.Imagen[0] != Img)
                            {
                                if ((item.Nombre == ""))
                                {
                                    item.Nombre = "No se encontro";
                                }
                                else
                                {
                                    if (item.Categoria.Descripcion == "")
                                    {
                                        item.Categoria.Descripcion = "No se encontro";
                                    }
                                    else
                                    {
                                        if (item.Marca.Descripcion == "")
                                        {
                                            item.Marca.Descripcion = "No se encontro";
                                        }
                                    }
                                }
                            
                    %>
                    <div class="carousel-item">
                        <img src="<%:Img%>" class="d-block w-100 " alt="..." onerror="this.onerror=null;this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';" style="width: 450px; height: 450px;">
                    </div>
                    <%}
                        }%>
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
        
        <div class="col">
       
        <div class="card">       
            <div class="card-body" style="background-color:#adb5bd">
                <h5 class="card-title"><%:item.Nombre %></h5>
                <p class="card-text"> <%:item.Descripcion %></p>
            </div>
            <div class="card-body" style="background-color:#e9ecef;color:forestgreen">
                <h5 class="card-title">$ <%:item.Precio %></h5>
            </div>
                <ul  class="list-group list-group-flush" >
                    <li style="background-color:#e9ecef" class="list-group-item">Id : <%:item.ID %></li>
                    <li style="background-color:#e9ecef" class="list-group-item">Codigo : <%:item.Codigo %></li>
                    <li style="background-color:#e9ecef" class="list-group-item">Marca : <%:item.Marca %></li>
                    <li style="background-color:#e9ecef" class="list-group-item">Categoria : <%:item.Categoria %></li>                                 
                </ul>
            <div class="card-body" style="display:flex;justify-content: center;background-color:#e9ecef;">            
                <asp:Button ID="btnAgregar" runat="server" class="btn btn-outline-success" Text="Agregar al carrito" OnClick="btnAgregar_Click" />
            </div>
            </div>

         </div>
    </div>
            <div class="card" style="background-color:#e9ecef; margin-top:250px">
                <div class="card-body">                                             
                    <div style="text-align:end; margin:10px">
                        <asp:Button ID="btnCarrito" runat="server" class="btn btn-outline-success" Text="Ver mi Pedido" OnClick="btnCarrito_Click" />
                    </div>  
                </div>
            </div>
        </div>
</asp:Content>
