<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Medium_UI.aspx.cs" Inherits="AttendanceManagementSystem.Admin_UI.Medium_UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-info">
                <div class="panel-heading">Medium</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-3"></div>
                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <label class="control-label" for="txtMedium">Medium</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMedium" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdnMediumUpdate" runat="server" />
                                </div>
                            </div>
                        <div class="col-md-3"></div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline pull-right" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-outline pull-right" onClick="btnSave_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <asp:GridView ID="gvMedium" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Style="width: 100%" OnRowDeleting="gvMedium_RowDeleting" OnSelectedIndexChanging="gvMedium_SelectedIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="hdnMediumID" Value='<%# Bind("MediumID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:BoundField DataField="MediumName" HeaderText="Medium" />
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
        <div class="col-md-2"></div>
    </div>

</asp:Content>
