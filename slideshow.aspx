<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slideshow.aspx.cs" Inherits="part2.slideshow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" runat="server" href="style/part2.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <title>Picture Slideshow</title>
</head>

<body>
    <form id="form1" runat="server">
        <nav class="navbar">
            <ul class="navbar-nav" style="flex-direction: row;">
                <li class="nav-item">
                    <a class="nav-link" href="https://hanzhangzhaopart2.azurewebsites.net/tma3.html">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="https://hanzhangzhaopart2.azurewebsites.net/visitorCookie.aspx">Part 1</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="https://hanzhangzhaopart2.azurewebsites.net/slideshow.aspx">Part 2</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="https://hanzhangzhaopart3.azurewebsites.net/Default">Part 3</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="https://hanzhangzhaopart4.azurewebsites.net/Default">Part 4</a>
                </li>
            </ul>
        </nav>
        <div class="slideContainer">
            <div class="slideshowJumbotron">
                <h2>Photo Slideshow</h2>
                <p class="lead">
                    A web application with ASP.NET in C# that runs a slideshow of a list of pictures inside a database.
                </p>
            </div>
            <div class="top">
                <div class="leftControl">
                    <asp:Button ID="StartStopButton" runat="server" Text="Start" OnClick="StartStopButton_Click" CssClass="btn btn-primary" />
                </div>
                <div class="midControl">
                    <asp:Button ID="SequentialRandomButton" runat="server" Text="Sequential" OnClick="SequentialRandomButton_Click" CssClass="btn btn-primary" />
                </div>
            </div>

            <div class="Container">

                <div class="midContent">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="PhotoTimer" runat="server" Enabled="False" Interval="2000" OnTick="PhotoTimer_Tick"></asp:Timer>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Photo Index 1"></asp:Label>
                            <br />
                            <div class="leftContent">
                                <asp:Button ID="backwardBtn" runat="server" Text="<" OnClick="BackwardButton_Click" CssClass="btn" />
                            </div>
                            <asp:Image ID="PhotoDisplay" runat="server" Width="480px" ImageUrl="~/img/Fairmont Banff Springs hotel, AB.jpg" />
                            <div class="rightContent">
                                <asp:Button ID="forwardBtn" runat="server" Text=">" OnClick="ForwardButton_Click" CssClass="btn" />
                            </div>
                            <br />
                            <asp:Label ID="CaptionLabel" runat="server" Text="Fairmont Banff Springs hotel, AB"></asp:Label>
                            <asp:HiddenField ID="RandomOn" runat="server" Value="false"></asp:HiddenField>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
