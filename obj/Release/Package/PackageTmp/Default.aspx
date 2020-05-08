<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Qup._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- HOME ICON SECTION  -->
  <section id="home-icons" class="py-5">
      <div class="container">
          <div class="row">
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-beer fa-3x"></i>
                  <h3>23 Restaurants signed up.</h3>
              </div>
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-users fa-3x"></i>
                  <h3>150 Users queued in!</h3>
              </div>
              <div class="col-md-4 mb-4 text-center">
                  <i class="fas fa-fast-forward fa-3x"></i>
                  <h3>50+ fast tracked.</h3>
              </div>
          </div>
      </div>
  </section>

    <!-- Sample Bar --> 
    <section class="my-4 py-4 bg-light">
        <div class="container">

            <div class="row my-4 py-4">
              <div class="col">
                  <div class="container mt-3 py-4 text-black-50 text-center">
                      <h1>Popular Bars and Night Clubs</h1>
                  </div>
              </div>
          </div>

            <div class="card-columns my-3">
              <div class="card">
                  <img class="card-img-top" src="Images/Bar101.jpeg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Bar 101</h4>
                    <p class="card-text">7 Sale Street</p>
                    <a href="Bar101View.aspx" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger"><img src="Images/icons8-clock.svg" style="width:20px" /> 65 mins</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Dr Rudi's.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Dr Rudi's</h4>
                    <p class="card-text">66-68 Tyler St, Britomart</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/FreemanGrey.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Freeman & Grey</h4>
                    <p class="card-text">85 Fort St, central city</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Headquarters.jpeg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Headquarters</h4>
                    <p class="card-text">91 Federal St, central city</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Revelry.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Revelry</h4>
                    <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Images/Sweat Shop Brew Kitchen.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">Sweat Shop Brew Kitchen</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">Profile</a>
                <a href="#" class="btn btn-danger">Queue Full</a>
                
                <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Images/The Fox.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Fox</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">Profile</a>
                <a href="#" class="btn btn-danger">Queue Full</a>
                
                <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Images/The Roxy.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Roxy</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">Profile</a>
                    <a href="#" class="btn btn-danger">Queue Full</a>
                    
                    <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Images/The Roxy.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Roxy</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">Profile</a>
                    <a href="#" class="btn btn-danger">Queue Full</a>
                    
                    <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
        </div>
        </div>
    </section>

    <!-- Sample Restaurants --> 
    <section class="my-4 py-4">
        <div class="container">

            <div class="row my-4 py-4">
              <div class="col">
                  <div class="container mt-3 py-4 text-black-50 text-center">
                      <h1>Popular restaurants</h1>
                  </div>
              </div>
          </div>

            <div class="card-columns my-3">
              <div class="card">
                  <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Cafe BBQ Duck</h4>
                    <p class="card-text">42c High Street</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Ponsonby Central</h4>
                    <p class="card-text">136-146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest3.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Prego Restaurant</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-success">Available</a>
                      
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Sidart Restaurant </h4>
                    <p class="card-text">283 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-success">Available</a>
                      
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Mekong Baby</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">The Blue Breeze inn</h4>
                    <p class="card-text">146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      
                  </div>
            </div>
        </div>
        </div>
    </section>    
</asp:Content>
