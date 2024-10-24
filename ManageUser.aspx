<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="AuthenticationonWeb.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Manage User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    </br>
    </br>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand">        
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        
        <Columns>

            <asp:TemplateField HeaderText="Profile">
                <ItemTemplate >
                    <asp:Image ImageUrl='<%#Eval("uprofile") %>' Height="100px" Width="100px" runat="server"></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>

<asp:TemplateField HeaderText="Name">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("name") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="User Name">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("uname") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField  HeaderText="Email ID">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("uemail") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Contact">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("ucontact") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Role">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("urole") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Status">
    <ItemTemplate>
        <asp:Label runat="server"  Text='<%#Eval("ustatus") %>' ></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="Button1" CommandName="Status" CommandArgument='<%#Eval("uid") %>' runat="server" Text='<%# Eval("ustatus").ToString() == "Active" ? "Block" : "Unblock" %>' />
            </ItemTemplate>
        </asp:TemplateField>

        </Columns>
        
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
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
