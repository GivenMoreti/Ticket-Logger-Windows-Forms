<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTicket.aspx.cs" Inherits="Moreti_TG_39141004_Assessment_3.UpdateTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <link rel="stylesheet" type="text/css" href="styles2.css" />
<head runat="server">
    <title>Update ticket</title>
</head>
<body>
    <form id="form1" runat="server">
         <table style="width: 80%;">
     <tr>
         <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
         <td>
             <div>
                 <h1>Update your ticket</h1>
             </div>
         </td>
         <td></td>
     </tr>
     <tr>
         <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
         <td>
             <div class="TicketDetails">

                 <div class="EmplIdClass1">
                     <div class="EmplIdClass1">
                         <asp:TextBox ID="EmpId1" runat="server" placeholder="Employee id"></asp:TextBox><br />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmpId1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                     <div class="EmplIdClass1">
                         <asp:TextBox ID="Name1" runat="server" placeholder="Employee Name"></asp:TextBox>
                         <br />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="Name1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                     <div class="EmplIdClass1">
                         <asp:TextBox ID="IssueDescription1" runat="server" placeholder="Issue Description"></asp:TextBox><br />
                         <asp:RequiredFieldValidator ControlToValidate="IssueDescription1" ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>

                     <div class="EmplIdClass1">
                         <asp:TextBox ID="Email1" runat="server" placeholder="Email1"></asp:TextBox><br />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email" ControlToValidate="Email1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                     </div>

                 </div>

                 <div class="EmplIdClass1">
                     <div class="statusDB1">
                         <h3>Status</h3>
                         <asp:DropDownList ID="StatusDropDown1" runat="server"></asp:DropDownList>
                     </div>
                     <div class="priorityDB1">
                         <h3>Priority</h3>
                         <asp:DropDownList ID="PriorityDropDown1" runat="server"></asp:DropDownList><br />
                     </div>
                     <div class="departmentDB1">
                         <h3>Department</h3>
                         <asp:DropDownList ID="DepartmentDropDown1" runat="server"></asp:DropDownList><br />
                     </div>
                 </div>

                 <div class="EmplIdClass1">
                     <asp:TextBox ID="Comments1" runat="server" placeholder="Comments" Rows="3"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Comments1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                 </div>

                 <div>
                     <h2>When do you expect the problem to be resolved?</h2>
                     <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                 </div>

                 <asp:Button ID="UpdateTicketBtn" runat="server" Text="Update Ticket" OnClick="UpdateTicketBtn_Click" />



             </div>


             <div>
             </div>
             <asp:Label ID="LblDisplay" runat="server" Text=""></asp:Label>

         </td>
         <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
     </tr>

 </table>
    </form>
</body>
</html>
