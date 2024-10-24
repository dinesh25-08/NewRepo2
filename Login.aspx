<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AuthenticationonWeb.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-selection">
            <button type="button" id="passwordLoginBtn" class="btn btn-primary">Login by Password</button>
        </div>

        <div id="passwordLogin" class="login-container">
            <asp:Label ID="Label1" runat="server" Text="Login by Password" CssClass="login-title"></asp:Label>
            <div class="form-group">
                <label for="TextBox1">Email ID</label>
                <asp:TextBox ID="TextBox1" type="text" runat="server" placeholder="Enter Email Id" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox2">Password</label>
                <asp:TextBox ID="TextBox2" type="password" runat="server" placeholder="Enter Password" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="Button1_Click" />
            <div>
                <a data-toggle="modal" data-target="#exampleModal" class="forgot-password" href="#">Forgot Password</a>
            </div>
        </div>

        <div class="login-selection">
    <button type="button" id="otpLoginBtn" class="btn btn-secondary">Login by OTP</button>
</div>

        <div id="otpLogin" class="login-container" style="display:none;">
            <asp:Label ID="Label2" runat="server" Text="Login by OTP" CssClass="login-title"></asp:Label>
            <div class="form-group">
                <label for="TextBox5">Email ID</label>
                <asp:TextBox ID="TextBox5" type="text" runat="server" placeholder="Enter Email Id" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group otp-container">
                <asp:Button ID="Button3" CssClass="btn btn-sm btn-secondary" runat="server" Text="Send OTP" OnClick="Button3_Click" />
            </div>
            <div class="form-group">
                <label for="TextBox6">Enter OTP</label>
                <asp:TextBox ID="TextBox6" type="text" runat="server" placeholder="Enter OTP" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button4" CssClass="btn btn-success" runat="server" Text="Verify OTP" OnClick="Button4_Click" />
        </div>

        <!-- Modal for Password Reset -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Reset Password</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email address</label>
                            <asp:TextBox ID="TextBox3" placeholder="Enter Email" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group otp-container">
                             <asp:Button ID="Button5" CssClass="btn btn-sm btn-secondary" runat="server" Text="Send OTP" OnClick="Button5_Click" />
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Enter OTP</label>
                            <asp:TextBox ID="TextBox7" placeholder="Enter OTP" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">New Password</label>
                            <asp:TextBox ID="TextBox4" placeholder="Enter New Password" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Reset" OnClick="Button2_Click" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#passwordLoginBtn').click(function () {
                $('#passwordLogin').show();
                $('#otpLogin').hide();
            });

            $('#otpLoginBtn').click(function () {
                $('#otpLogin').show();
                $('#passwordLogin').hide();
            });
        });
    </script>
</body>
</html>
