<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bar1010View.aspx.cs" Inherits="Qup._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h1 style="font-size:75px;color:#343A40">Bar101</h1>
        
        <h2 style="color:#343A40"><img src="Images/icons8-clock.svg" style="height:50px" /> Queue Time : <span id="span-time" style="color:red;font-weight:bold;text-decoration:underline">65 minutes</span></h2>
        <div id="qrcode" style="display:none;margin:auto;border:2px solid grey; width:90%;"><img src="Images/qr-code.svg" class="img img-responsive" /></div>
        <center><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3192.698262917691!2d174.7619877152674!3d-36.84970187993844!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6d0d47fab390f1d1%3A0x9e79f6a32b63f329!2sBar%20101%20Auckland!5e0!3m2!1sen!2snz!4v1588462236040!5m2!1sen!2snz" width="90%" height="300" frameborder="0" style="border:0;margin:auto; width:90%" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe></center>
        <div class="justify-content-xl-center" style="display:flex;justify-content:space-around;flex-direction:row;padding:20px">

            <!--<img src="Images/bar101lineNarrow.jpg" alt="bar101" class="img" style="width:100%" /> -->
            <a class="btn btn-danger">Join the Queue</a>
            <a class="btn btn-success" onclick="doSkip()">Skip the Queue</a>
        <div>
            
        </div>  
    </div>
        
        <script>function doSkip(){
    document.getElementById("pop-up-pay").style.setProperty('display','flex');
            }
            function doAcc() {
                document.getElementById("pop-up-pay").style.setProperty('display', 'none');
                document.getElementById("pop-up-accepted").style.setProperty('display', 'flex');
            }
            function doDone() {
                document.getElementById("pop-up-accepted").style.setProperty('display', 'none');
                document.getElementById("qrcode").style.setProperty('display', 'block');
                var span = document.getElementById("span-time");
                span.style.setProperty('color', 'green');
                span.innerHTML = "5 minutes";
            }
        </script>
    <div id="pop-up-pay" style="display:none;flex-direction:column;justify-content:space-between;position:fixed;top:50%;left:50%;transform:translateX(-50%)translateY(-50%);width:80%;height:300px;background-color:lightgrey;border-radius:10px;border:solid black 1px;padding:10px;">
        <h3>Current QJump Price: $10</h3>
        <h4>Queue Time with Jump: 5 mins</h4>
        <h4>Time Saved: 60 mins</h4>
        <a class="btn btn-success" onclick="doAcc()">Jump Queue</a>
        <a class="btn btn-secondary">Cancel</a>
    </div>
         <div id="pop-up-accepted" style="display:none;flex-direction:column;justify-content:space-between;position:fixed;top:50%;left:50%;transform:translateX(-50%)translateY(-50%);width:80%;height:300px;background-color:lightgrey;border-radius:10px;border:solid black 1px;padding:10px;">
        <h3>You've Jumped The Queue!</h3>
        <h4>Bar101 will be expecting you in 5 mins</h4>
        <h4>Have the QR Code on you profile ready when you arrive.</h4>

        <a class="btn btn-info" onclick="doDone()">Done</a>
    </div>
</asp:Content>
