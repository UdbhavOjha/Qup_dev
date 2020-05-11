<%@ Page Title="Qup | Admin" Language="C#" MasterPageFile="~/Managers.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Qup.Manager.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="home-icons" class="py-3 bg-light">
        <div class="container">
            <div class="row">
                <div class="col mb-2 text-center p-2 mr-1">
                    <h3>
                        <span class="badge badge-info"> <%:ManagerDasboardData.CustomersAtPresent %> </span> 
                        <span class="h5">out of</span> 
                        <span class="badge badge-danger h3"><%:ManagerDasboardData.Capacity %></span>
                    </h3>                                                  
                    <p>Customers at present</p>
                </div>
                <div class="col mb-2 text-center p-2 ml-1">
                    <h3 class="text-success">
                        <span class="badge badge-success"><%:ManagerDasboardData.CustomersServedToday %></span>
                    </h3> 
                    <p>Customers Served Today</p>
                </div>
            </div>
        </div>
    </section>
    <section id="managerActions">
        <div class="container my-2 py-2">
            <div class="row">
                <div class="col text-center">
                    <!-- Button trigger modal -->
                    <button type="button" class="btn btn-outline-success" data-toggle="modal" data-target="#addnewCustomerModal">
                      Add New Customer
                    </button>
                    <!-- Modal -->
                    <div class="modal fade" id="addnewCustomerModal" tabindex="-1" role="dialog" aria-labelledby="addnewCustomerModalLabel" aria-hidden="true">
                      <div class="modal-dialog" role="document">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title" id="addnewCustomerModalLabel">Add New Customer</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                          <div class="modal-body">
                            <div class="form-group">
                                <label for="name" class="col-form-label">Name</label>
                                <input type="text" class="form-control" id="name" name="name" runat="server">
                              </div>
                              <div class="form-group">
                                <label for="email" class="col-form-label">Email</label>
                                <input type="text" class="form-control" id="email" name="email" runat="server">
                              </div>
                              <div class="form-group">
                                <label for="mobile" class="col-form-label">Mobile Number</label>
                                <input type="text" class="form-control" id="mobile" name="mobile" runat="server">
                              </div>
                          </div>
                          <div class="modal-footer">
                              <asp:Button id="submit" Class="btn btn-success" Text="Save" OnClick="saveSubmit_Click" runat="server" />
                              <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>                            
                          </div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="customerSection" class="mt-2 pt-2">
        <div class="container">
            <div class="row">
                <div class="col display-4 text-center">
                    Customer Details
                </div>                
            </div>
            <div class="row">
                <div class="col text-secondary text-center">
                    <%: DateTime.Now.ToString("dd MMM yyyy hh:mm tt") %>
                </div>                
            </div>
            <div class="row">
                <div class="col text-secondary text-center">
                    <small>The queue results refreshes at every 00:00 hrs</small>
                </div>                
            </div>
        </div>
    </section>
    <section id="showCustomerServedToday">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <table class="table" id="customerToday">
                          <thead>
                            <tr>
                              <th scope="col">#</th>
                              <th scope="col">Name</th>
                              <th scope="col">Entry Time</th>
                              <th scope="col">Exit Time</th>
                            </tr>
                          </thead>
                          <tbody>
                              
                                  <%  int i = ManagerDasboardData.Customers.Count();
                                      foreach (var item in ManagerDasboardData.Customers)
                                      { %>
                                <tr>
                                    <td><%:i%></td>
                                    <td><%:item.Name %></td>
                                    <td><%:item.QueueEntryTime %></td>
                                    <td><%if (item.QueueExitTime == null)
                                            { %>
                                        <input type="button"  onClick="Delete(<%:item.QueueId %>);" class="btn btn-outline-danger" value="Leave" />
                                        <% }
                                        else {%>
                                        <%:item.QueueExitTime %>
                                        <%} %>

                                    </td>
                                   </tr>  

                                   <% i--;
                                       } %>
                                            
                          </tbody>
                        </table>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>

    </section>

    <%--Scripts--%>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            var table = $('#customerToday').DataTable();
            table.order([0, 'desc']).draw();

           // $('#customerToday').DataTable({
           //     "order": [1, "desc"]
           //});
        });

        function Delete(id) {
            var input = document.createElement("input");
            input.type = "text";
            input.name = "deleteId";
            input.value = id;
            document.getElementById("form1").appendChild(input);

            document.getElementById("form1").submit();
        }
    </script>
    
    
</asp:Content>
