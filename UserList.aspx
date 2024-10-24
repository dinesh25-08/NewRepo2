<%@ Page Title="User List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AuthenticationonWeb.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    User List

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 20px; text-align: center;">
        <asp:TextBox ID="TextBox1" runat="server" 
            style="width: 30%; padding: 10px; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; display: inline-block;"
            placeholder="Enter Name"></asp:TextBox>

        <asp:Button ID="Button1" runat="server"
            style="background-color: #28a745; color: white; padding: 10px 20px; border: none; border-radius: 4px; cursor: pointer; display: inline-block; margin-left: 10px;"
            Text="Search" 
            OnClientClick="this.style.backgroundColor='#218838';" 
            OnClientMouseOut="this.style.backgroundColor='#28a745';" OnClick="Button1_Click" />

        <br /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" 
            style="margin: 0 auto;" OnRowDeleting="GridView1_RowDeleting">
        
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        
        <Columns>

            <asp:TemplateField HeaderText="Profile Picture">
                <ItemTemplate>
                    <asp:Image height="100" Width="100" ID="Image1" runat="server" ImageUrl='<%# Eval("uprofile") %>' />
                </ItemTemplate>
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="ID">
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("uid") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
        <asp:Label ID="Label7" runat="server" Text='<%# Eval("name") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>           
            
            <asp:TemplateField HeaderText="Username">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("uname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("uemail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Contact">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ucontact") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("urole") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ustatus") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
    <ItemTemplate>

        <asp:Button ID="Button2" runat="server" CommandName="Delete" Class="btn btn-sm btn-danger" CommandArgument="Delete" Text="Delete" />

    </ItemTemplate>
</asp:TemplateField>

        </Columns>

        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

    </asp:GridView>

    </asp:Content>
