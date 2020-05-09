<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Qup.Admins.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- HOME ICON SECTION  -->
      <section id="home-icons" class="py-5 bg-light">
          <div class="container">
              <div class="row">
                  <div class="col mb-4 text-center p-4 mr-1">
                      <i class="fas fa-beer fa-5x"></i>
                      <h3>0 Restaurants signed up.</h3>
                  </div>
                  <div class="col mb-4 text-center p-4 ml-1">
                      <i class="fas fa-users fa-5x"></i>
                      <h3>0 Users signed up.</h3>
                  </div>
              </div>
          </div>
      </section>
    <section id="searchSection" class="mt-4 pt-4">
        <div class="container">
            <div class="row">
                <div class="col display-4 text-center">
                    Search
                </div>                
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="form-group">
                        <label for="searchType">Search Type</label>
                        <select class="form-control" id="searchType" runat="server">
                          <option value="Business">Business</option>
                          <option value="User">User</option>
                        </select>
                      </div>
                    <div class="form-group">
                        <label for="userType">User Type</label>
                        <select class="form-control" id="userType" runat="server">
                          <option value="Patron">Patron</option>
                          <option value="Manager">Manager</option>
                            <option value="AdminSupport">Admin Support</option>
                        </select>
                      </div>
                    <div class="form-group">
                        <label class="form-text">Name</label>
                        <div class="form-row">
                            <div class="col">
                                <input type="text" class="form-control" placeholder="Enter Name" id="name" value="" name="name" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group py-2 mb-4">
                        <asp:Button id="search" Class="btn btn-outline-info" Text="Search" OnClick="searchSubmit_Click" runat="server" />
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </section>
    <%--Search Results--%>
    <section id="searchResultsSection">
        <div id="container" class="mt-4 pt-4">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <% if(searchResultsCount != 0)
        {%>
           <% if (userSearchResults != null) 
            { %>
            <table class="table table-striped">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Name</th>
                  <th scope="col">Email</th>
                  <th scope="col">Phone</th>
                </tr>
              </thead>
              <tbody>
                
                    <%  int i = 1;
                        foreach (var item in userSearchResults)
                        {%>
                  <tr>
                    <td><%:i%></td>
                    <td><%:item.FullName %></td>
                    <td><%:item.Email %></td>
                    <td><%:item.PhoneNumber %></td>
                  </tr> 
                       <% i++;
                           } %>
                  
                               
              </tbody>
            </table>

            <% }
            else
            {

            }

        }
 %>
                </div>
                <div class="col-md-1"></div>
            </div>        
        </div>
    </section>
</asp:Content>
