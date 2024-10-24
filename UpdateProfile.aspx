<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="AuthenticationonWeb.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Edit Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList  ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">

        <ItemTemplate>


            <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%#Eval("uprofile") %>' />
            <br />
            <br />


            <br />
            Name :<asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
            <br />
           
            Username:<asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval("uname") %>'></asp:TextBox>
            <br />
           
            Email:<asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval("uemail") %>'></asp:TextBox>
            <br />
            
            Contact :<asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval("ucontact") %>'></asp:TextBox>
            <br />
           
            Photo:<asp:FileUpload ID="FileUpload1" runat="server"  Text='<%#Eval("uprofile") %>'  />
            <br />
           
            <asp:Button ID="Button4" runat="server" CommandName="update" CommandArgument='<%#Eval("uid") %>' Text="Update" />
            <br />



        </ItemTemplate>

    </asp:DataList>

</asp:Content>
