<%@ Page Title="" Language="C#" MasterPageFile="~/Patrons.Master" AutoEventWireup="true" CodeBehind="PatronDashboard.aspx.cs" Inherits="Qup.Clients.PatronDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section id="home-icons" class="py-5">
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
  </section>--%>

    <!-- Sample Bar -->
    <%--<section id="" class="py-5 bg-light">
      <div class="container">
          <div class="row">
              <div class="col mb-4 text-center">
                  <h1>Get into a new queue</h1>
              </div>
          </div>
          <div class="row my-4 py-4">
              <div class="col">
                  <!-- Search form -->
                <div class="md-form mt-0">
                    <input class="form-control" type="text" placeholder="Search your favourite hangout place" aria-label="Search">
                </div>
                <div class="md-form my-2">
                    <asp:Button class="btn btn-success" type="submit" runat="server" Text="Search" ID="search" OnClick="search_Click"></asp:Button>
                </div>
              </div>
            </div>
      </div>
    </section>--%>
    <section class="py-4 bg-light">
        <div class="container">     
          
            <div class="card-columns my-3">
              <div class="card">
                  <img class="card-img-top" src="/Images/Kingslander.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">The Kingslander</h4>
                    <p class="card-text">470 New North Road, Kingsland, Auckland</p>
                    <a href="#" class="btn btn-primary">Profile</a>
                      <a href="#" class="btn btn-danger">Queue</a>
                  </div>
              </div>
              <%--<div class="card">
                <img class="card-img-top" src="/Images/Dr Rudi's.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Dr Rudi's</h4>
                    <p class="card-text">66-68 Tyler St, Britomart</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/FreemanGrey.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Freeman & Grey</h4>
                    <p class="card-text">85 Fort St, central city</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Headquarters.jpeg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Headquarters</h4>
                    <p class="card-text">91 Federal St, central city</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Revelry.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Revelry</h4>
                    <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="/Images/Sweat Shop Brew Kitchen.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">Sweat Shop Brew Kitchen</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">See Profile</a>
                <a href="#" class="btn btn-danger">Queue Full</a>
                <a href="#" class="btn btn-secondary">Map</a>
                <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="/Images/The Fox.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Fox</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">See Profile</a>
                <a href="#" class="btn btn-danger">Queue Full</a>
                <a href="#" class="btn btn-secondary">Map</a>
                <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="/Images/The Roxy.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Roxy</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">See Profile</a>
                    <a href="#" class="btn btn-danger">Queue Full</a>
                    <a href="#" class="btn btn-secondary">Map</a>
                    <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="/Images/The Roxy.jpg" alt="Card image">
                <div class="card-body">
                <h4 class="card-title">The Roxy</h4>
                <p class="card-text">Downstairs, 38 Roukai Lane, Britomart</p>
                <a href="#" class="btn btn-primary">See Profile</a>
                    <a href="#" class="btn btn-danger">Queue Full</a>
                    <a href="#" class="btn btn-secondary">Map</a>
                    <a href="#" class="btn btn-danger">Jump Q</a>
                </div>
            </div>
            <div class="card">
                  <img class="card-img-top" src="/Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Cafe BBQ Duck</h4>
                    <p class="card-text">42c High Street</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-danger">Queue Full</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                      <a href="#" class="btn btn-danger">Jump Q</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Ponsonby Central</h4>
                    <p class="card-text">136-146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Rest3.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Prego Restaurant</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-success">Available</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Sidart Restaurant </h4>
                    <p class="card-text">283 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-success">Available</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Rest5.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">Mekong Baby</h4>
                    <p class="card-text">226 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                  </div>
              </div>
              <div class="card">
                <img class="card-img-top" src="/Images/Rest1.jpg" alt="Card image">
                  <div class="card-body">
                    <h4 class="card-title">The Blue Breeze inn</h4>
                    <p class="card-text">146 Ponsonby Road</p>
                    <a href="#" class="btn btn-primary">See Profile</a>
                      <a href="#" class="btn btn-warning">Get in line Fast</a>
                      <a href="#" class="btn btn-secondary">Map</a>
                  </div>
            </div>  --%>
        </div>
        </div>
    </section>
              
</asp:Content>
