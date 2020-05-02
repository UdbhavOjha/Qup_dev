<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Qup.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="logon" class="h-100">
            <div class="container h-100">
                <div class="row justify-content-center align-items-center h-100 px-2">
                    <div class="col-md-3"></div>
                    <div class="col-md-6 loginBorder" style="padding: 3% 5%;">
                        <div class="row">
                            <h4 class="text-muted lead">
                                Admin Login
                            </h4>
                        </div>
                        <div class="row text-muted">
                            <small>Username</small>
                        </div>
                        <div class="row">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <i class="far fa-user"></i>
                                    </span>
                                </div>
                                <input type="text" class="form-control" id="username" name="username" placeholder="Username or Email Address" />
                            </div>
                        </div>
                        <div class="row text-muted mt-3">
                            <small>Password</small>
                        </div>
                        <div class="row">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1">
                                        <i class="fas fa-user-lock"></i>
                                    </span>
                                </div>
                                <input class="form-control" id="password" name="password" type="password" placeholder="Password"  />
                            </div>
                        </div>
                        <%--<div class="row mt-2 py-2">
                            <a href="/Base/ForgotPassword.aspx">
                                <small class="text-primary">Forgot Your Password</small>
                            </a>
                        </div>--%>
                        <div class="row my-2">
                            <asp:Button class="btn btn-success" type="submit" runat="server" Text="Login" ID="login" OnClick="login_Click"></asp:Button>
                        </div>
                        <%--<div class="row mt-2 py-2">
                            <small class="text-muted">
                                 Don't have an account? <a href="/SignUp.aspx" class="text-primary">Create one</a> 
                            </small>
                        </div>--%>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>
        </section>
</asp:Content>
