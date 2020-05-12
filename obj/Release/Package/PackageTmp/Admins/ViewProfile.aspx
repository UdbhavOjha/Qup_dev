<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="Qup.Admins.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="BusinessProfileSection">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="card text-center">
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <img class="card-img-top" id="businessProfileQuickResponseCodeImage" alt="Card image cap" runat="server" />
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                      
                      <div class="card-body">
                        <h5 class="card-title"><%:BusinessDetails.BusinessName %></h5>
                          <p class="card-text"><%:BusinessDetails.Address %></p>
                          <p class="card-text">Capacity: <span class="border border-success rounded p-2"><%:BusinessDetails.Capacity %></span></p>        
                      </div>
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>

    </section>    
</asp:Content>
