<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Qup.Admins.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- HOME ICON SECTION  -->
      <section id="home-icons" class="py-5">
          <div class="container">
              <div class="row">
                  <div class="col mb-4 text-center border border-info rounded p-4 mr-1">
                      <i class="fas fa-beer fa-5x"></i>
                      <h3>0 Restaurants signed up.</h3>
                  </div>
                  <div class="col mb-4 text-center border border-info rounded p-4 ml-1">
                      <i class="fas fa-users fa-5x"></i>
                      <h3>0 Users signed up.</h3>
                  </div>
              </div>
          </div>
      </section>
</asp:Content>
