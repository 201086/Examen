<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="Examen.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="section">
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <h2 class="header">Actualizar</h2>
                    <div class="input-field col s12">
                        <input id="nombre" type="text" />
                        <label id="lblNombre" for="nombre">Nombre:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_paterno" type="text" />
                         <label id="lblApellidoPaterno" for="apellido_paterno">Apellido Paterno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_materno" type="text" />
                        <label id="lblApellidoMaterno" for="apellido_materno">Apellido Materno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="correo" type="text" />
                        <label id="lblCorreo" for="correo">Correo:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <a class="waves-effect waves-light btn" onclick="return actualizar(event)">Actualizar</a>
                </div>
            </div>
        </div>
    </div>
    <script src="js/guardar.js"></script>
</asp:Content>
