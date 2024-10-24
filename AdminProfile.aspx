<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="AuthenticationonWeb.AdminProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">

            <ItemTemplate>
<h3 style="color:darkblue;font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">Update Profile</h3>
        <div class="card" style="width: 18rem;">
  <img class="card-img-top" src='<%#Eval("uprofile") %>' alt="Card image cap">
            <br>
  </br>
            <div class="card-body">
    <h5 class="card-title">Name :<%#Eval("name") %></h5>
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item"><b>User Name:</b><%#Eval("uname") %></li>
      <br>
      
    <li class="list-group-item"><b>Email :</b><%#Eval("uemail") %></li>
      <br>
      
    <li class="list-group-item"><b>Contact :</b><%#Eval("ucontact") %></li>
      <br>
     
    <li class="list-group-item"><b>Role :</b><%#Eval("urole") %></li>
  </ul>
  <div class="card-body">

      <asp:Button class="btn btn-secondary" CommandName="Update" CommandArgument='<%#Eval("uid") %>' ID="Button1" runat="server" Text="Edit" />

  </div>
</div>

    </ItemTemplate>

    </asp:DataList>


</asp:Content>

