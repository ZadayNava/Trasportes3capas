<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCamiones.aspx.cs" Inherits="Trasportes3capas.Catalogos.camiones.ListadoCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Listado de Camiones</h3>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click"/>
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVCamiones" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="Id_camion"
                OnRowDeleting="GVCamiones_RowDeleting"
                OnRowCommand ="GVCamiones_RowCommand"
                OnRowEditing="GVCamiones_RowEditing"
                OnRowUpdating="GVCamiones_RowUpdating"
                OnRowCancelingEdit="GVCamiones_RowCancelingEdit"
                >
                <%--arriba se genera los eventos "onrow"--%>
                <Columns>
                    <asp:BoundField DataField="Id_camion" HeaderText="Numero de camion"  ItemStyle-Width="50px" ReadOnly="true"/>
                    <asp:BoundField DataField="matricula" HeaderText="Matrícula" ItemStyle-Width="50px"/>
                    <asp:BoundField DataField="tipo_camion" HeaderText="Tipo_camion" ItemStyle-Width="50px"/>
                    <asp:TemplateField HeaderText="Disponibilidad" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width: 100%">
                                <div style="width:25%; margin:0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>' Enabled="false" />
                                </di>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%; margin:0 auto">
                                    <asp:CheckBox ID="chkEditDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>' />
                                </div>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="urlFoto" HeaderText="urlFoto" ItemStyle-Width="85px"/>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="urlFoto"></asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px"/>
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px"/>
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px"/>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
