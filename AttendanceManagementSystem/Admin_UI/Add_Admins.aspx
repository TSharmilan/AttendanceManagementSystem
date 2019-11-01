<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Add_Admins.aspx.cs" Inherits="AttendanceManagementSystem.Admin_UI.Add_Admins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <div class="panel panel-info">
                <div class="panel-heading">Admin</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtName">Name</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnAdminUpdate" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtEmpNo">Employee No</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEmpNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtUserName">UserName</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtPassword">Password</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <asp:Panel runat="server" Visible="false" ID="pnlSuccess">
                                <div class="alert alert-success">
                                    <strong>Success!</strong> Admin Added Successfully!!!.
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="col-md-3"></div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline pull-right" OnClick="btnClear_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-outline pull-right" OnClick="btnSave_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100%" OnRowDeleting="gv_RowDeleting" OnSelectedIndexChanging="gv_SelectedIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="hdnAdminID" Value='<%# Bind("AdminID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:BoundField DataField="EmpNo" HeaderText="Employee No" />
                                                <asp:BoundField DataField="AdminName" HeaderText="Admin Name" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:CommandField ShowSelectButton="true" />
                                        </Columns>
                                            <RowStyle CssClass="rowStyle" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                            <div class="col-md-3"></div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-md-1"></div>
    </div>

</asp:Content>
