<%@ Page Title="Qup | Admin" Language="C#" MasterPageFile="~/Managers.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Qup.Manager.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="home-icons" class="py-5">
      <div class="container text-secondary">
          <div class="row ">
              <div class="col-md-4 mt-4 pt-4 text-center">
                  <div class="p-2 border border-success rounded"> 
                      <i class="fas fa-user fa-2x"></i>
                      <h3><span class="badge badge-success">43</span> / <span class="badge badge-danger">45</span></h3>
                      <h5 class="text-secondary">Customers in the house</h5>
                  </div>                  
              </div>              
              <div class="col-md-4 mt-4 pt-4  text-center">
                  <div class="p-2 border border-warning rounded"> 
                      <i class="fas fa-user-clock fa-2x"></i>
                    <h3><span class="badge badge-warning">25</span></h3>
                    <h5 class="text-secondary">Customers in queue</h5>
                  </div>

                  
              </div>
              <div class="col-md-4 mt-4 pt-4  text-center">
                  <div class="p-2 border border-info rounded">
                      <i class="fas fa-hourglass-half fa-2x"></i>
                    <h3><span class="badge badge-info">15 minutes</span></h3>
                    <h5 class="text-secondary">Current waiting time</h5>
                  </div>                  
              </div>
          </div>
          <div class="row">
              <div class="col-md-4 mt-4 pt-4  text-center">
                  <div class="p-2 border border-success rounded">
                      <i class="fas fa-user fa-2x"></i>
                      <h3><span class="badge badge-success">1045</span></h3>
                    <h5>Average daily customers</h5>
                  </div>                  
              </div>              
              <div class="col-md-4 mt-4 pt-4  text-center">
                  <div class="p-2 border border-success rounded">
                      <i class="fas fa-user-clock fa-2x"></i>
                    <h3><span class="badge badge-success">4550</span></h3>
                    <h5>Average weekly customers</h5>
                  </div>
                  
              </div>
              <div class="col-md-4 mt-4 pt-4  text-center">
                  <div class="p-2 border border-info rounded">
                      <i class="fas fa-hourglass-half fa-2x"></i>
                    <h3><span class="badge badge-info">7 minutes</span></h3>
                     <h5>Average daily waiting time</h5>
                  </div>                  
              </div>
          </div>
      </div>
  </section>

    <!-- table --> 
    <section class="mt-4">
        <div class="container">
            <div class="row">
                <div class="col mb-4 text-center">
                    <h3 class="text-secondary">Customers</h3>
                </div>
            </div>
            <div class="row">
                <div class="col mb-4">
                    <span class="btn btn-outline-secondary"><i class="fa fa-table" aria-hidden="true"></i> Download</span>
                    <span class="btn btn-outline-secondary"><i class="fas fa-share-alt"></i> Share</span>                    
                </div>
                <div class="col mb-4">
                    <p class="float-right">
                        <span class="btn btn-outline-secondary">
                            <i class="fas fa-user"></i> Add New Customer
                        </span>
                    </p>                 
                </div>
            </div>
            
            <table class="table table-hover">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Name</th>
                  <th scope="col">Status</th>
                    <th scope="col">Action</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">1</th>
                  <td>Mark Otto</td>
                  <td class="text-success">In the house</td>
                    <td></td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob Thornton</td>
                  <td class="text-danger">In Queue</td>
                  <td>
                      <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                  </td>
                </tr>
                <tr>
                  <th scope="row">3</th>
                  <td>Larry the Bird</td>
                  <td class="text-success">In the house <span class="badge badge-info">Jumped Q</span></td>
                    <td></td>
                </tr>
                <tr>
                  <th scope="row">4</th>
                  <td>Kane Williamson</td>
                  <td class="text-success">In the house</td>
                    <td></td>
                </tr>
                <tr>
                <th scope="row">5</th>
                    <td>Martin Guptill</td>
                    <td class="text-success">In the house</td>
                    <td></td>
                </tr>

                <tr>
                  <th scope="row">6</th>
                  <td>Mark Otto</td>
                  <td class="text-danger">In Queue</td>
                    <td>
                        <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                    </td>
                </tr>
                <tr>
                  <th scope="row">7</th>
                  <td>Jacob Thornton</td>
                  <td class="text-danger">In Queue</td>
                  <td>
                      <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                  </td>
                </tr>
                <tr>
                  <th scope="row">8</th>
                  <td>Larry the Bird</td>
                  <td class="text-danger">In Queue</td>
                    <td>
                        <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                    </td>
                </tr>
                <tr>
                  <th scope="row">9</th>
                  <td>Kane Williamson</td>
                  <td class="text-danger">In Queue</td>
                    <td>
                        <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                    </td>
                </tr>
                <tr>
                <th scope="row">10</th>
                    <td>Martin Guptill</td>
                    <td class="text-danger">In Queue</td>
                    <td>
                        <span class="btn btn-outline-success">Accept</span>
                        <span class="btn btn-outline-danger">Deny</span>
                    </td>
                </tr>
              </tbody>
            </table>
        </div>
    </section>
    
</asp:Content>
