<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistration_UI.aspx.cs" Inherits="AttendanceManagementSystem.User_Interface.StudentRegistration_UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">Student Registration</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-4">
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="gp1" HeaderText="Please Fill the * marked fields:" runat="server" Font-Size="Small" ForeColor="Red" ShowSummary="true"/>
                        </div>
                        <div class="col-md-8"></div>
                    </div>
                 
                    <div class="row"> 
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtSchool">School</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtSchool" CssClass="form-control" runat="server" value="Kn/Murugananda College" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtIndexNo">Index Number<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtIndexNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="txtIndexNo" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="rbtListGender">Gender<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:RadioButtonList ID="rbtListGender" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                        <asp:ListItem Value="Male">Male &nbsp&nbsp&nbsp</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="rbtListGender" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtFName">First Name<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtFName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="txtFName" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtLName">Last Name<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="txtLName" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="ddlGrade">Grade<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" TabIndex="7" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="ddlGrade" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="ddlDivision">Division<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" TabIndex="7" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="ddlDivision" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="ddlMedium">Medium<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" TabIndex="7" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="ddlMedium" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtDOB">Date of Birth<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDOB" Textmode="date" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="txtDOB" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtAddress">Address<span style="color: red">*</span></label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="please fill FamilyBookNo"  ControlToValidate="txtAddress" ValidationGroup="gp1" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtAddress1">Address</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtPhoneNo">Phone No</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtEmail">Email</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <asp:Panel runat="server" Visible="false" ID="pnlSuccess">
                                <div class="alert alert-success">
                                    <strong>Success!</strong> Student Added Successfully!!!.
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="col-md-3"></div>
                    </div>
                    <br />
                    <br />

                     <div class="row">
                        <div class="col-md-12">
                            <%--<asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default pull-right" />--%>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info pull-right" onClick="btnSave_Click" />
                        </div>
                    </div>
                            
                </div>
            </div>
        </div>
    </div>
</asp:Content>

