<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apresentacao.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>    
    <meta name="description" content="Sistema de Gerenciamento de Tarefas" />
    <meta name="author" content="Luís Gabriel Nascimento Simas" />    

    <title>Sistema de Gerenciamento de Tarefas - Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">Autentica&ccedil;&atilde;o de Usu&aacute;rios</h2>
            <asp:Label runat="server" class="sr-only" Text="Login:"/>            
            <asp:TextBox CssClass="form-control" placeholder="Entre o Login" required autofocus ID="txtLogin" runat="server"/>        

            <asp:Label runat="server" class="sr-only" Text="Senha:"/>                    
            <asp:TextBox CssClass="form-control" placeholder="Entre com a Senha" TextMode="Password" required ID="txtSenha" runat="server" />                            
        <asp:Button CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Entrar" OnClick="AutenticarUsuario"/>
        </form>
        
        <asp:Label runat="server" ID="lblmensagem"/>

    </div>
    
</body>
</html>
