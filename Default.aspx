<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Qup._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- HOME ICON SECTION  -->
  <section id="home-icons" class="py-5">
      <div class="container">
          <div class="row">
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-beer fa-5x"></i>
                  <h3>23 Restaurants signed up.</h3>
              </div>
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-users fa-5x"></i>
                  <h3>150 Users queued in!</h3>
              </div>
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-fast-forward fa-5x"></i>
                  <h3>50+ fast tracked.</h3>
              </div>
          </div>
      </div>
  </section>


    <!-- Sample Restaurants --> 
    <section>
        <div class="container">

            <div class="row my-4 py-4">
              <div class="col">
                  <div class="container mt-3 py-4 text-black-50 text-center">
                      <h1>Top 6 in demand restaurants</h1>
                  </div>
              </div>
          </div>


            <div class="card-columns my-3">
              <div class="card">
                  <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Cafe BBQ Duck</h4>
                    <p class="card-text">42c High Street</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Ponsonby Central</h4>
                    <p class="card-text">136-146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest3.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Prego Restaurant</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Sidart Restaurant </h4>
                    <p class="card-text">283 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Mekong Baby</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">The Blue Breeze inn</h4>
                    <p class="card-text">146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                  </div>
            </div>
        </div>
        </div>
    </section>


</asp:Content>

