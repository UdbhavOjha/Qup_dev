<%@ Page Title="New Business" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewBusinessOnboard.aspx.cs" Inherits="Qup.Admins.NewBusinessOnboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--User Message Section--%>
        <section id="UserMessageSection" style="display: none;">
            <div id="UserMessage" class="my-4 py-4">
               <% if (UserMessage != "") { %>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-8">
                                <div class="card">
                                    <% if (UserMessage.Contains("success"))
                                        { %>
                                    <div class="card-header text-success">
                                        Success!
                                    </div>
                                    <div class="card-body text-success">
                                        <%:UserMessage %> 
                                    </div>
                                    <%}
                                    else if (UserMessage.Contains("fail"))
                                    {%>
                                    <div class="card-header text-danger">
                                        Failed!
                                    </div>
                                    <div class="card-body text-danger">
                                        <%:UserMessage %> 
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                    </div>
                <% }%>
            </div>
        </section>
    <section id="signUpFormSection" style="min-height: 100%;">
        <div class="container mt-4 py-4 mb-4">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <h1 class="text-muted text-center">
                        Onboard a new business on the platform
                    </h1>
                    <div class="text-center">
                        <small class="lead text-muted">Please fill all the mandatory details</small>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>
            <div class="row mt-4">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div class="form-group py-4">
                        <label class="form-text h5">Name of Company / Business / Organisation <span>&#42;</span></label>
                        <div class="row">
                            <div class="col pb-1">
                                <input type="text" class="form-control" name="companyName" id="companyName" placeholder="Please enter your company's name" runat="server" >
                            </div>
                        </div>
                    </div>
                    <div class="form-group py-4">
                        <label class="form-text h5">Address <span>&#42;</span></label>
                        <div class="row">
                            <div class="col pb-1">
                                <textarea type="text" rows="5" class="form-control" id="address" name="address" placeholder="Please enter the address of your business or organisation with City and Post Code." runat="server"></textarea>
                            </div>
                        </div>
                        <small class="text-muted">Address is mandatory.</small>
                    </div>
                    <div class="form-group py-4">
                        <label class="form-text h5">Seating Capacity <span>&#42;</span></label>
                        <div class="input-group">
                          <div class="input-group-prepend">
                            <span class="input-group-text">
                               <i class="fas fa-utensils"></i>
                            </span>
                          </div>
                          <input type="text" class="form-control" placeholder="Enter maximum seating capacity" id="seatingCapacity" name="seatingCapacity" value="" runat="server" />
                        </div>
                        <small class="form-text text-muted">This is a mandatory field.</small>
                    </div>
                    
                    <div class="form-group py-4">
                        <label class="form-text h5">Name of Administrator or Business Owner <span>&#42;</span></label>
                        <div class="form-row">
                            <div class="col pb-1">
                                <input type="text" class="form-control" id="firstName" name="firstName" value=""  placeholder="First Name" runat="server" />
                            </div>
                            <div class="col pb-1">
                                <input type="text" class="form-control" placeholder="Last Name" id="lastName" value="" name="lastName" runat="server" />
                            </div>
                        </div>
                        <small class="text-muted">First name is mandatory.<br/>The name entered will be the administrator of your Qup account.</small>
                    </div>
                    
                    <div class="form-group py-4">
                        <label class="form-text h5">Mobile Number <span>&#42;</span></label>
                        <div class="input-group">
                          <div class="input-group-prepend">
                            <span class="input-group-text">
                               <i class="fas fa-mobile-alt"></i>
                            </span>
                          </div>
                          <div class="input-group-prepend">
                            <span class="input-group-text">
                               +64
                            </span>
                          </div>
                          <input type="text" class="form-control" placeholder="Enter phone number" value="" id="mobileNumber" name="mobileNumber" runat="server" />
                        </div>
                        <small class="form-text text-muted">This is a mandatory field. All communications regarding your Qup account will be sent to this mobile number.</small>
                    </div>
                    <div class="form-group py-4">
                        <label class="form-text h5">Email address <span>&#42;</span></label>
                        <div class="input-group">
                          <div class="input-group-prepend">
                            <span class="input-group-text">
                               <i class="far fa-envelope-open"></i>
                            </span>
                          </div>
                          <input type="text" class="form-control" placeholder="Enter email address" id="email" name="email" value="" runat="server" />
                        </div>
                        <small class="form-text text-muted">This is a mandatory field. All communications regarding your Qup account will be sent to this email address.</small>
                    </div>
                    <div class="form-group py-4">
                        <label class="form-text h5">Password <span>&#42;</span></label>
                        <div class="input-group">
                          <div class="input-group-prepend">
                            <span class="input-group-text">
                               <i class="fas fa-unlock-alt"></i>
                            </span>
                          </div>
                          <input type="password" class="form-control" placeholder="Enter password" id="password" name="password" value="" runat="server" />
                        </div>
                        <small class="form-text text-muted">This is a mandatory field. All communications regarding your Qup account will be sent to this email address.</small>
                    </div>
                    <div class="form-group py-4 mb-4">
                        <asp:Button id="submit" Class="btn btn-success" Text="Create account" OnClick="signUpSubmit_Click" runat="server" />
                    </div>
                </div>
                </div>
            </div>
    </section>

    <script>
        
        <% if (UserMessage != "") {%>
        document.getElementById('UserMessageSection').style.display = '';
        <% } %>

        $(document).ready(function () {
            $('#firstName').val("");
            $('#lastName').val("");
            $('#mobileNumber').val("");
            $('#email').val("");
            $('#email').text("");
            $('#address').val("");
            $('#companyName').val("");
            $('#description').val("");
            $('#userName').val("");
            $('#password').val("");
            $('#password').text("");
            $('input[type="password"]').val('');
        });
    </script>
</asp:Content>
