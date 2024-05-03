<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Moreti_TG_39141004_Assessment_3.Dashboard" %>

<!DOCTYPE html>
<link rel="stylesheet" href="styles.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td></td>
                <td>
                    <h1>Dashboard</h1>

                </td>
                <td>

                    <div>
                        <asp:Button ID="CreateTicketBtn2" runat="server" Text="Add Ticket" OnClick="CreateTicketBtn_Click" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="actionButtons">
                      
                        <asp:Button ID="GoHomeBtn" runat="server" Text="Go back" OnClick="GoHomeBtn_Click" />
                        <asp:Button ID="RetrieveAllBtn" runat="server" Text="Retrieve All" OnClick="RetrieveAllBtn_Click" />
                        <asp:Button ID="DeleteTicketBtn" runat="server" Text="Close Ticket" OnClick="DeleteTicketBtn_Click" />
                        <asp:Button ID="UpdateTicketBtn" runat="server" Text="Update Ticket" OnClick="UpdateTicketBtn_Click" />
                    </div>
                </td>
                <td>

                    <div class="searchItems">
                          <div class="searchBox">

                              <asp:TextBox ID="SearchById" runat="server" placeholder="search by id"></asp:TextBox>
                              <asp:Button ID="SearchIdBtn" runat="server" Text="Search id" OnClick="SearchIdBtn_Click" />
                          </div>

                        <div class="searchBox">
                            <asp:TextBox ID="SearchByIssue" runat="server" placeholder="search by issue"></asp:TextBox>
                            <asp:Button ID="SearchIssueBtn" runat="server" Text="Search issue" OnClick="SearchIssueBtn_Click" />
                        </div>

                        <div class="searchBox">
                            <asp:TextBox ID="SearchByStatus" runat="server" placeholder="search by status"></asp:TextBox>
                            <asp:Button ID="SearchStatusBtn" runat="server" Text="Search status" OnClick="SearchByStatusBtn_Click" />
                        </div>


                        <div class="searchBox">
                            <asp:TextBox ID="SearchByDepartment" runat="server" placeholder="search by department"></asp:TextBox>
                            <asp:Button ID="SearchDepartmentBtn" runat="server" Text="Search department" OnClick="SearchDepartmentBtn_Click" />
                        </div>

                        <div class="searchBox">
                            <asp:TextBox ID="SearchByPriority" runat="server" placeholder="search by priority"></asp:TextBox>
                            <asp:Button ID="SearchPriorityBtn" runat="server" Text="Search priority" OnClick="SearchPriorityBtn_Click" />
                        </div>

                    </div>

                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <div class="gridViewContainer">
                        <asp:GridView ID="GridViewTickets" runat="server"></asp:GridView>
                    </div>

                    <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
