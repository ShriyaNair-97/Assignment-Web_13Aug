<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DMLQuery.aspx.cs" Inherits="WebAppQuery.DMLQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
            Employee Id:<asp:TextBox ID="TxtEmpId" runat="server"></asp:TextBox>
            <br />
            Employee Name :&nbsp; <asp:TextBox ID="TxtEmpName" runat="server"></asp:TextBox>
            <br />
            <br />
            Employee Salary :
            <asp:TextBox ID="TxtEmpSal" runat="server"></asp:TextBox>
            <br />
            <br />
            Gender:
            <asp:TextBox ID="TxtGender" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnEmp" runat="server" OnClick="BtnEmp_Click" Text="InsertEmployee" />
            <br />
            <asp:Button ID="BtnEmp1" runat="server" OnClick="BtnEmp1_Click" Text="InsertEmpProcedure" />
            <br />
            <asp:Button ID="BtnEmp2" runat="server" OnClick="BtnEmp2_Click" Text="InsertWithparameters" />
            <br />
            <br />
            <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="UpdateEmployee" />
            <br />
            <asp:Button ID="BtnUpdate1" runat="server" OnClick="BtnUpdate1_Click" Text="UpdateProcedure" />
            <br />
            <asp:Button ID="btnUpdateWithParameter" runat="server" OnClick="btnUpdateWithParameter_Click" Text="UpdateWithParameters" />
            <br />
            <br />
            <asp:Button ID="BtnDelete2" runat="server" OnClick="BtnDelete2_Click" Text="DeleteEmployee" />
            <br />
            <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="DeleteProcedure" />
            <br />
            <asp:Button ID="BtnDeleteWithParametr" runat="server" OnClick="BtnDeleteWithParametr_Click" Text="DeleteWithParameter" Width="234px" />
            <br />
            <br />
            <br />
            <asp:Button ID="BtnSelect" runat="server" OnClick="BtnSelect_Click" Text="Select" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnDisconnected" runat="server" OnClick="BtnDisconnected_Click" Text="DisconnectedShowGrid" />
        </div>
    </form>
</body>
</html>
