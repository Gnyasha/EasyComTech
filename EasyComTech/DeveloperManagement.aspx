<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeveloperManagement.aspx.cs" Inherits="EasyComTech.DeveloperManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="padding: 10px">

        <div class="box box-success">
            <div class="box-header">
                <h3 class="box-title">Registered Developers</h3>
            </div>
            <div class="box-body">


                <asp:GridView class="table table-bordered table-striped" runat="server">
                </asp:GridView>

                <asp:GridView ID="grdDevs" class="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="grdDevs_RowCommand" OnSelectedIndexChanged="grdDevs_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdDevs_PageIndexChanging" runat="server">
                    <Columns>



                        <asp:BoundField DataField="FullName" HeaderText="Name" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:BoundField DataField="Skype" HeaderText="Skype" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Id" HeaderText="Developer Id" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>

                                <asp:Button ID="btnSelectDev" CssClass="btn btn-info btn-sm upload-btn" runat="server" CausesValidation="false" CommandName="SelectDev"
                                    Text="More" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:Button ID="btnDeleteDev" CssClass="btn btn-info btn-sm upload-btn" runat="server" CausesValidation="false" CommandName="RemoveDev"
                                    Text="Remove" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>

            </div>
            <!-- /.box-body -->

        </div>
        <!-- /.box -->
    </div>
</asp:Content>
