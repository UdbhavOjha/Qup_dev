<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="Qup.LogOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--logout section--%>
    <section id="logout" class="h-100">
            <div class="container" style="margin-top: 100px;">
                <div class="row justify-content-center align-items-center h-75 px-2">
                    <div class="col">
                        <div class="row justify-content-center ">
                            <i class="fas fa-sign-out-alt fa-4x p-4 border border-secondary rounded-circle"></i>
                        </div>
                        <div class="row justify-content-center mt-4">
                            <small class="text-muted text-center" style="font-size: 15px;">
                                You have been successfully signed out. Click <a href="/Login.aspx">here</a> to Login again. 
                            </small>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    <style>
        html,body{
            width:100%;
            margin:0;
            height:90%;
        }
    </style>
</asp:Content>
