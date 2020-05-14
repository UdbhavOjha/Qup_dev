<%@ Page Title="" Language="C#" MasterPageFile="~/Patrons.Master" AutoEventWireup="true" CodeBehind="JoinQueue.aspx.cs" Inherits="Qup.Clients.JoinQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (BusinessConfig.BusinessName != null) { %>

    <section class="BusinessProfileSection">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="card text-center border-secondary">
                        <img src="/Images/Kingslander.jpg" class="card-img-top" id="businessProfileQuickResponseCodeImage" alt="Card image cap" runat="server" />

                        <div class="card-body">
                        <h5 class="card-title"><%:BusinessConfig.BusinessName %></h5>
                          <p class="card-text"><%:BusinessConfig.Address %></p>
                          <input type="text" value="<%:BusinessConfig.BusinessId %>" id="businessId" name="businessId" hidden/>

                            <%if (!disableJoinQueueButton) {%>
                            <div>
                              <asp:Button type="submit" class="btn btn-lg btn-success" runat="server" Text="Join Queue" OnClick="joinQueue_Click" />
                            </div>
                            <%} if (enableLeaveQueueButton)
                                {%>
                            <div>
                              <asp:Button type="submit" class="btn btn-lg btn-danger" runat="server" Text="Leave" OnClick="leaveQueue_Click" />                                
                            </div>
                           <%} %>
                            <%if (UserMessage != null) %>
                            <div>                              
                                <div class="text-success"><%:UserMessage%></div>
                            </div>
                      </div> 
                    </div>                      
                                           
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </section>

     <% } %>
</asp:Content>
