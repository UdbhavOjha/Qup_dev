<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatronSignUp.aspx.cs" Inherits="Qup.PatronSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="signUpFormSection" style="min-height: 100%;">
        <div class="container mt-4 py-4 mb-4">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <h1 class="text-muted text-center">
                        Create your patron account with Qup today
                    </h1>
                    <div class="text-center">
                        <small class="lead text-muted">Start your free one month trial subscription by signing up here</small>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>
            <div class="row mt-4">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div class="form-group py-4">
                        <label class="form-text h5">Name <span>&#42;</span></label>
                        <div class="row">
                            <div class="col pb-1">
                                <input type="text" class="form-control" name="companyName" id="companyName" placeholder="Please enter your company's name" runat="server" />
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
                    <div class="form-group py-4 mb-4">
                        <asp:Button id="submit" Class="btn btn-success" Text="Create my account" OnClick="signUpSubmit_Click" runat="server" />
                    </div>
                </div>
                </div>
            </div>
    </section>
</asp:Content>
