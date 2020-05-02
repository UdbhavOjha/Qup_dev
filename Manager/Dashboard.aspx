<%@ Page Title="Qup | Admin" Language="C#" MasterPageFile="~/Managers.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Qup.Manager.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="home-icons" class="py-5">
      <div class="container">
          <div class="row">
              <div class="col-md-4 my-4 py-4 text-center">
                  <i class="fas fa-user-clock fa-4x"></i>
                  <h3>Active Queues</h3>
              </div>              
              <div class="col-md-4 my-4 py-4 text-center">
                  <i class="fas fa-user-friends fa-4x"></i>
                  <h3>Add Friends</h3>
              </div>
              <div class="col-md-4 my-4 py-4 text-center">
                  <i class="fas fa-user-cog fa-4x"></i>
                  <h3>Manage Preferences</h3>
              </div>
          </div>
      </div>
  </section>
</asp:Content>
