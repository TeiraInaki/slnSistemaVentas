<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaVendedor.aspx.cs" Inherits="AppWebVentas.VistaVendedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="DNI"></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Comision"></asp:Label>
            <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnTraerPorId" runat="server" Text="Traer por Id" OnClick="btnTraerPorId_Click" />
            <asp:Button ID="btnTraerPorComision" runat="server" Text="Traer por Comision" OnClick="btnTraerPorComision_Click" />
            <asp:GridView ID="gridVendedores" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
