<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Examen.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .id{
            display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row">
            <h2 class="header">Lista</h2>
            <div class="section col s12 m12 l12">
                <a href="Agregar.aspx" class="waves-effect waves-light btn">Crear</a>
            </div>
            <br/>
            <br/>
            <br/>
            <table id="gridClientes"></table>
        </div>
        <script src="js/lista.js"></script>
    </div>
</asp:Content>