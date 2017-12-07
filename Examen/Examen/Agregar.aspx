<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Examen.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <h2 class="header">Crear</h2>
                    <div class="input-field col s12">
                        <input id="nombre" type="text" />
                        <label for="nombre">Nombre:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_paterno" type="text" />
                         <label for="apellido_paterno">Apellido Paterno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="apellido_materno" type="text" />
                         <label for="apellido_materno">Apellido Materno:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="correo" type="text" />
                         <label for="correo">Correo:</label>
                    </div>
                </div>
            </div>
            <div class="col s12">
                <div class="row">
                    <a class="waves-effect waves-light btn" onclick="return agregar(event);">Agregar</a>
                </div>
            </div>
        </div>
    </div>
    <script src="js/agregar.js"></script>
</asp:Content>