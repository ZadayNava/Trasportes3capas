<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formularioCamiones.aspx.cs" Inherits="Trasportes3capas.Catalogos.camiones.formularioCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="subTitulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%--formulario--%>
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
                    <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje"></asp:Label>
                    <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
                    <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de camion"></asp:Label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--Campos especiales--%>
                    <br /><br />
                    <asp:Label ID="lbldisponibiidad" runat="server" Text="Disponibilidad"></asp:Label>
                    <br />
                    <asp:CheckBox ID="chkdisponibilidad" runat="server" />
                    <br /><br />
                    <asp:Label ID="lblimagen" runat="server" Text="Imagen"></asp:Label>
                    <input type="file" id="subeimagen" runat="server" CssClass="btn btn-group" />
                    <asp:Button ID="btnsubeimagen" runat="server" CssClass="btn btn-primary" Text="Subir Imagen" onclick="btnsubeimagen_Click"/>
                    <asp:Label ID="lblurlfoto" runat="server" Text="Foto"></asp:Label>
                    <asp:Image ID="imgfoto" Width="100" Height="100" runat="server"/>
                    <asp:Image ID="imgcamion" Width="100" Height="100" runat="server"/>
                    <asp:Label ID="urlfoto" runat="server"></asp:Label>
                    <asp:Button ID="btngurdar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btngurdar_Click" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
