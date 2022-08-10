<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multimark.aspx.cs" Inherits="Magfinalproject.multimark" EnableSessionState="True"  %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       
<link href="~/AdenCss/bootstrap.rtl.css" rel="stylesheet" />
        
<script src="~/vendor1/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- Core plugin JavaScript-->

</head>
<body>
    <form id="form1" runat="server">
    <div style="direction: rtl" class="row">
        <div class="col-md-12" style="direction: rtl;margin-top:10px">
        <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="#993399" C />
        <asp:Button ID="btnupload"  Style="margin-left:10px;margin-right:15px" runat="server" Text="تحميل" OnClick="btnupload_Click"  />
            </div>
        <div class="col-md-12" style="direction: rtl;margin-top:10px">
            <asp:Label ID="Label3" runat="server"  Style="margin-left:10px;margin-right:15px" Text=" الفصل الدراسي :"></asp:Label>
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        </asp:DropDownList>
            <asp:Label ID="Label4" runat="server"  Style="margin-left:10px;margin-right:15px" Text="القسم :"></asp:Label>
         <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True" OnTextChanged="DropDownList2_TextChanged">
        </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Style="margin-left:10px;margin-right:15px" Text="المادة الدراسية :"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
        <div class="col-md-12" style="direction: rtl;margin-top:10px">
        <asp:GridView  CssClass="table" ID="GridView1" runat="server"></asp:GridView>
            </div>
       
        <asp:Button ID="Button2" style="direction: rtl;margin-top:10px" runat="server" OnClick="Button2_Click" Text="حفظ" />
       
        <br />
    </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       
        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
       
    </form>
</body>
</html>

