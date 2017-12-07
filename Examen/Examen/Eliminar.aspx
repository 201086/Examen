<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="Examen.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <h2 class="header">Eliminar</h2>
                    <div class="input-field col s12">
                        <input id="nombre" readonly />
                        <label id="lblNombre" for="nombre">Nombre:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_paterno" readonly />
                        <label id="lblApellidoPaterno" for="apellido_paterno">Apellido Paterno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_materno" readonly/>
                        <label id="lblApellidoMaterno" for="lblApellidoMaterno">Apellido Materno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="correo" readonly />
                        <label id="lblCorreo" for="lblCorreo">Correo:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <a class="waves-effect waves-light btn" onclick="return eliminar(event);">Eliminar</a>
                </div>
            </div>
        </div>
    </div>
    <script src="js/eliminar.js"></script>
</asp:Content>
