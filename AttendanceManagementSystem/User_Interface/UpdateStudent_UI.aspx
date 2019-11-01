<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateStudent_UI.aspx.cs" Inherits="AttendanceManagementSystem.User_Interface.UpdateStudent_UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">Update Student</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-1">
                                    <label class="control-label" for="txtIndexNo">Index No</label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtIndexNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            <div class="col-md-3"></div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />


                    <asp:Panel runat="server" ID="pnlExist" Visible="false">
                        <div class="row">
                            <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="alert alert-danger">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Black" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            <div class="col-md-2"></div>
                        </div>
                    </asp:Panel>

                    <div class="row">
                        <div class="col-md-10">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info pull-right" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />


                    <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group label-floating">
                                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100%" OnSelectedIndexChanging="gv_SelectedIndexChanging"  OnRowDeleting="gv_RowDeleting"
                                            OnPageIndexChanging="gv_PageIndexChanging" OnDataBound="gv_DataBound">
                                         
                                            <Columns>
                                                <asp:TemplateField ControlStyle-CssClass="hideGridColumn">
                                                    <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>
                                                        <asp:HiddenField runat="server" ID="hdnStudentID" Value='<%# Bind("StudentID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IndexNo" HeaderText="Student Index No"/>
                                                <asp:BoundField DataField="FName" HeaderText="First Name" />
                                                <asp:BoundField DataField="LName" HeaderText="Last Name" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:CommandField ShowSelectButton="true" />
                                      
                                                    </Columns>
                                            <RowStyle CssClass="rowStyle" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>


                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                            </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
