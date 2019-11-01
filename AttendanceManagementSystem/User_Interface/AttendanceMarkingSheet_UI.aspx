<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceMarkingSheet_UI.aspx.cs" Inherits="AttendanceManagementSystem.User_Interface.AttendanceMarkingSheet_UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">Marking Sheet</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-1">
                                    <label class="control-label" for="txtDate">Date</label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtDate" Textmode="date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            <div class="col-md-3"></div>
                        </div>
                        <br />
                        <br />
                        <br />

                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-1">
                                    <label class="control-label" for="ddlGrade">Grade</label>
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" TabIndex="7" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            <div class="col-md-3"></div>
                        </div>
                        <br />
                        <br />
                        <br />

                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-1">
                                    <label class="control-label" for="ddlDivision">Division</label>
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" TabIndex="7" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            <div class="col-md-3"></div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group label-floating">
                                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100%" OnSelectedIndexChanging="gv_SelectedIndexChanging"  OnRowDeleting="gv_RowDeleting">
                                         
                                            <Columns>
                                                <asp:TemplateField ControlStyle-CssClass="hideGridColumn">
                                                    <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IndexNo" HeaderText="Student Index No"/>
                                                <asp:BoundField DataField="FName" HeaderText="Name With Initial" />
                                            
                                        
                                              <asp:TemplateField  HeaderText="Attendence" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBOx" runat="server" Checked="true" OnCheckedChanged="chkBOx_CheckedChanged" AutoPostBack="true"  />
                                              
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                                    </Columns>
                                            <RowStyle CssClass="rowStyle" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>


                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                            </div>

                    <div class="row">
                        <div class="col-md-10">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
