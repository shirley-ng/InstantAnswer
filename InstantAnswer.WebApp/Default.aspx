<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InstantAnswer.WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InstantAnswer</title>
    <style>
        body { padding: 0; margin: 0; font-family: "arial"; }
        .abstractImage { float: left; padding-right: 10px; }
        .header {
            border: 10px solid lightblue;
            background-color: lightblue;
        }
        .answer {
            border: 10px solid white;
            max-width: 800px;
        }
        .duplicateAnswer { padding-top: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
        <div class="header">
            <h1>InstantAnswer</h1>
            <asp:TextBox ID="queryTextBox" runat="server"></asp:TextBox><asp:Button ID="queryButton" runat="server" Text="Query" OnClick="queryButton_Click" />
        </div>
        <div class="answer">
            <h2>
                <asp:Label ID="answerHeading" runat="server"></asp:Label>
            </h2>
            <asp:Image ID="answerImage" runat="server" CssClass="abstractImage" />
            <asp:Label ID="answerAbstractText" runat="server"></asp:Label>
            <asp:Repeater ID="duplicateAnswers" runat="server">
                <HeaderTemplate>
                    Duplicate answers found for '<%# queryTextBox.Text %>'
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="duplicateAnswer">
                        <%# Eval("Value") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label ID="noAnswerLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
