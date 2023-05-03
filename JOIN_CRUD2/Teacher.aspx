<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="JOIN_CRUD2.Teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <table>
                    <tr>
                        <td>
                            <table>
                                <h1>Teacher Detail</h1>
                                <tr>
                                    <td>Enter Teacher Id :</td>
                                    <td>
                                        <asp:TextBox ID="txttid" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Subject Id :</td>
                                    <td>
                                        <asp:DropDownList ID="ddsubjectid" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Lecture Id :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlectureid" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Teacher Name :</td>
                                    <td>
                                        <asp:TextBox ID="txtteachername" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Teacher Email :</td>
                                    <td>
                                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Teacher Mobileno :</td>
                                    <td>
                                        <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Teacher Address :</td>
                                    <td>
                                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                                        <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click" />
                                    </td>
                                </tr>
                            </table>

                            <br />
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </td>
                        <td>
                            <table>
                                <h1>Lecture Detail</h1>
                                <tr>
                                    <td>Enter Lecture Id :</td>
                                    <td>
                                        <asp:TextBox ID="txtlidforLecture" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch_lecture" runat="server" Text="Search" OnClick="btnSearch_lecture_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Class :</td>
                                    <td>
                                        <asp:TextBox ID="txtclass" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> Subject Id :</td>
                                    <td>
                                        <asp:DropDownList ID="ddsidforlecture" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btninsert_lecture" runat="server" Text="Insert" OnClick="btninsert_lecture_Click"  />
                                        <asp:Button ID="btnupdate_lecture" runat="server" Text="Update" OnClick="btnupdate_lecture_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btndelete_lecture" runat="server" Text="Delete" OnClick="btndelete_lecture_Click" />
                                        <asp:Button ID="btnview_lecture" runat="server" Text="View" OnClick="btnview_lecture_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddQuery" runat="server">
                                <asp:ListItem>--SELECT QUERY--</asp:ListItem>
                                <asp:ListItem>Query1</asp:ListItem>
                                <asp:ListItem>Query2</asp:ListItem>
                                <asp:ListItem>Query3</asp:ListItem>
                                <asp:ListItem>Query4</asp:ListItem>
                                <asp:ListItem>Query5</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
    </form>
</body>
</html>
