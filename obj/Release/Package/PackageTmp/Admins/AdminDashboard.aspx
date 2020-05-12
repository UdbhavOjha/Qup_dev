<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Qup.Admins.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- HOME ICON SECTION  -->
      <section id="home-icons" class="py-3 bg-light">
          <div class="container">
              <div class="row">
                  <div class="col mb-2 text-center p-2 mr-1">
                      <h3 class="text-success"><span class="badge badge-info"><%:businessesOnPlatformCount%> </span></h3> 
                      <p>Restaurants/Bars/Clubs</p>
                  </div>
                  <div class="col mb-2 text-center p-2 ml-1">
                      <h3 class="text-success">
                          <span class="badge badge-info"><%:registeredPatronsOnPlatformCount%></span>
                      </h3> 
                      <p>Patron Users</p>
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
                        <select class="form-control" id="searchType" runat="server" onchange="showUserDropDown();">
                          <option value="Business">Business</option>
                          <option value="User">User</option>
                        </select>
                      </div>
                    <div class="form-group" id="userTypeDiv" <%if (!userSearched) {%>style="display:none"<%} %>>
                        <label for="userType">User Type</label>
                        <select class="form-control" id="userType" runat="server">
                          <option value="Patron">Patron</option>
                          <option value="Manager">Manager</option>
                          <option value="AdminSupport">Admin Support</option>
                        </select>
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
    <section id="searchResultsSection" style="overflow-x:hidden">
        <div id="container" class="mt-4 pt-4">
            <%if (searchResultsCount >= 0) { %>            
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col">
                    <% if (searchResultsCount >= 1) {%>
                       <% if (userSearchResults.Count() > 0)
                        { %>
                        <table class="table" id="userResults">
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
                        else if( businessSearchResults.Count() > 0)
                        { %>
                        <table class="table" id="businessResults">
                          <thead>
                            <tr>
                              <th scope="col">#</th>
                              <th scope="col">Business Name</th>
                              <th scope="col">Address</th>
                              <th scope="col">Capacity</th>
                            <th scope="col"></th>
                            </tr>
                          </thead>
                          <tbody>
                
                                <%  int i = 1;
                            foreach (var item in businessSearchResults)
                            {%>
                              <tr>
                                <td><%:i%></td>
                                <td><%:item.BusinessName %></td>
                                <td><%:item.Address %></td>
                                <td><%:item.Capacity %></td>
                                  <td>
                                      <a href="/Admins/ViewProfile?businessId=<%:item.BusinessId%>" class="btn btn-outline-info" target="_blank"> Profile </a>
                                  </td>
                              </tr> 
                                   <% i++;
                                } %>
                  
                               
                          </tbody>
                        </table>

                        <% }

                    }
                    else if(searchResultsCount == 0)
                    {%>
                        <div class="row">
                            <div class="col-md-2"> </div>
                            <div class="col-md-8">
                                <div class="card">
                                      <div class="card-body">
                                        <p class="card-text text-danger ">Search yielded 0 results</p>                                    
                                      </div>
                                  </div>                             
                            </div>
                            <div class="col-md-2"></div>  
                        </div>
                                     
                    <%} %>
                </div>
                <div class="col-md-1"></div>
            </div>
            <%} %>
        </div>
    </section>

    <%--Scripts--%>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {
            var businessTable = $('#businessResults').DataTable();
            businessTable.draw();

            var userTable = $('#userResults').DataTable();
            userTable.draw();
        });

        function showUserDropDown()
        {
            var x = document.getElementById("ContentPlaceHolder1_searchType").value;
            if (x === "User") {
                document.getElementById("userTypeDiv").style.display = "block";
            } else {
                document.getElementById("userTypeDiv").style.display = "none";
            }
        }
        
    </script>
</asp:Content>
