<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home_UI.aspx.cs" Inherits="AttendanceManagementSystem.User_Interface.Home_UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../assets/css/slider.css" rel="stylesheet" />
    <link href="../assets/css/nivoSlider.css" rel="stylesheet" />
    <script src="../assets/js/slider.js"></script>
    <script src="../assets/js/nivoSlider.js"></script>


    <asp:ScriptManager ID="scriptManger1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <section id="slider-area">
                <div class="container">
                    <div class="row">
                       
                            <div id="slider" class="nivoSlider">
                                <img src="../assets/img/Slider-1.png" />
                                <img src="../assets/img/Slider-2.png" />
                                <img src="../assets/img/Slider-3.png" />
                                <img src="../assets/img/Slider-4.png" />
                            </div>
                            <!-- End of /.nivoslider -->
                    
                        <!-- End of /.col-md-12 -->
                    </div>
                    <!-- End of /.row -->
                </div>
                <!-- End of /.container -->
            </section>
            <!-- End of Section -->

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
