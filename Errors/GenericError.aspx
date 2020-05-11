<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericError.aspx.cs" Inherits="Qup.Errors.GenericError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.13/css/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp"
      crossorigin="anonymous">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB"
      crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ekko-lightbox/5.3.0/ekko-lightbox.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs4/dt-1.10.20/datatables.min.css"/> 
    
    <title>Qup</title>
</head>
<body>
    <!-- START HERE -->  
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark">
        <div class="container">
            <a href="#" class="navbar-brand">Qup</a>
            <button class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a href="/Login.aspx" class="nav-link">Login</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
<%--    <form id="form1" runat="server">
        <div>
        </div>
    </form>--%>
    <section>
        <div class="container mt-4 p-4">
            <div class="row display-4">
                Oops, something went wrong. Please login again. 
            </div>
        </div>
    </section>
    <!--Footer -->
    <footer id="main-footer" class="py-3 bg-dark text-light footer" style="position: absolute; bottom: 0; width: 100%;">
        <div class="container">
            <div class="text-center mb-0 pb-0">
                <div>
                    <p class="mb-2 pb-0">
                        Copyright &copy; <span> <%:DateTime.Now.Year%></span> Qup 
                    </p>
                </div>
            </div>
            <div class="text-center">
                <div>
                    <div>
                        Terms of use | Privacy  
                    </div>
                </div>
            </div>
        </div>        
    </footer>
</body>
</html>
