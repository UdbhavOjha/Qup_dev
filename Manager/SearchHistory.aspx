<%@ Page Title="" Language="C#" MasterPageFile="~/Managers.Master" AutoEventWireup="true" CodeBehind="SearchHistory.aspx.cs" Inherits="Qup.Manager.SearchHistory" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <!-- jQuery -->
    

    <!-- Datepicker -->
    <link href='https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css' rel='stylesheet' type='text/css'>    

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="clientSearchSection">
        <div class="container py-4">
            <div class="row text-center display-4 my-4 py-4">
                <div class="col">Search Customer Visits</div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4 align-self-center">
                    <div class="form-row align-items-center">
                        <div class="col-sm-4 col-form-label">
                            From Date
                        </div>
                        <div class="col-sm-8">                            
                            <div class="input-group">
                              <div class="input-group-prepend">
                                <span class="input-group-text">
                                   <i class="fas fa-calendar-alt"></i>
                                </span>
                              </div>
                              <input type="text" class="form-control datepicker" id="formDate" name="fromDate" value="" placeholder="DD/MM/YYYY" data-date-format="dd/mm/yyyy">
                            </div>
                        </div>
                    </div>
                    <div class="form-row  my-4 align-items-center">
                        <div class="col-sm-4 col-form-label">
                            To Date
                        </div>
                        <div class="col-sm-8">                            
                            <div class="input-group">
                              <div class="input-group-prepend">
                                <span class="input-group-text">
                                   <i class="fas fa-calendar-alt"></i>
                                </span>
                              </div>
                              <input type="text" class="form-control datepicker" id="toDate" name="toDate" value="" data-date-format="dd/mm/yyyy" placeholder="DD/MM/YYYY">
                            </div>
                        </div>
                    </div>
                    <div class="form-row mb-4 justify-content-center">
                        <asp:Button id="submit" Class="btn btn-outline-success" Text="Search" OnClick="searchSubmit_Click" runat="server" />
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>               
        </div>
    </section>

    <!-- Script -->    
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                endDate: "today"
             });
        });
    </script>
    
</asp:Content>
