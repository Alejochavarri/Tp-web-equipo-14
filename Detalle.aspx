<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_14.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!-- <div style="margin:10px">
       <asp:Button ID="btnVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="btnVolver_Click" />
    </div> -->
    
    <div class="row g-3" style="margin-top:10px;margin:20px">

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
            <div class="card-body">
                <h5 class="card-title"><%:item.Nombre %></h5>
                <p class="card-text"> <%:item.Descripcion %></p>
            </div>
            <div class="card-body">
                <h5 class="card-title">$ <%:item.Precio %></h5>
            </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">Id : <%:item.ID %></li>
                    <li class="list-group-item">Codigo : <%:item.Codigo %></li>
                    <li class="list-group-item">Marca : <%:item.Marca %></li>
                    <li class="list-group-item">Categoria : <%:item.Categoria %></li>                                 
                </ul>
            <div class="card-body" style="display:flex;justify-content: center;margin:30px">            
                <asp:Button ID="btnAgregar" runat="server" class="btn btn-outline-danger" Text="Agregar al carrito" OnClick="btnAgregar_Click" />
            </div>
            </div>

         </div>
    </div>
    <footer style="margin-top:20px;margin:20px">
        <div>
            <div class="card" >
                <div class="card-body">
                    <h5 class="card-title">Previsualizacion del carrito</h5>
                    <div style="display:flex;justify-content: space-between;margin:10px">
                        <label class="card-text">0 Elementos</label>
                        <label class="card-text" > $ 2000</label>                       
                    </div>          
                    <div style="text-align:end; margin:10px">
                        <a href="#" class="btn btn-danger"  ">Ver Mi Pedido</a>
                    </div>  
                </div>
            </div>
        </div>
    </footer>
</asp:Content>
