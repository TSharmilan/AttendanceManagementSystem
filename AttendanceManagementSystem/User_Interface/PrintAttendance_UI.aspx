<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintAttendance_UI.aspx.cs" Inherits="AttendanceManagementSystem.User_Interface.PrintAttendance_UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function printDiv(printPanelDiv) {
            var printContents = document.getElementById(printPanelDiv).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }

    </script>

    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">Print Attendance</div>
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
                        <br />
                        <br />

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

                    <div id="printPanelDiv" class="col align-self-center" style="height: auto; width: 100%; padding: 0 5%">
                    <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group label-floating">
                                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100%" OnSelectedIndexChanging="gv_SelectedIndexChanging"  OnRowDeleting="gv_RowDeleting">
                                         
                                            <Columns>
                                                <asp:TemplateField ControlStyle-CssClass="hideGridColumn">
                                                    <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>
                                                        <%--<asp:HiddenField runat="server" ID="MemberID" Value='<%# Bind("MemberID") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StudentNO" HeaderText="Student Index No"/>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="year" runat="server" Text='<%#Eval("year")+ "-" + Eval("month")+ "-" + Eval("date")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="FName" HeaderText="Name With Initial" />--%>
                                                <asp:BoundField DataField="AttendanceMark" HeaderText="Attendance" />

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

                    <div class="row">
                        <div class="col-md-10">
                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="printDiv('printPanelDiv')" CssClass="btn btn-info pull-right" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
