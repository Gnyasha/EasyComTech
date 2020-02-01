<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeveloperRegistration.aspx.cs" Inherits="EasyComTech.DeveloperRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Tabs" role="tabpanel">

        <!-- Nav tabs -->
        <asp:HiddenField ID="TabName" runat="server" />
        <ul class="nav nav-tabs" role="tablist">

            <li><a href="#Occupation" aria-controls="contact" role="tab" data-toggle="tab">Occupation area /Área de atuação</a></li>
            <li><a href="#Knowledge" aria-controls="identification" role="tab" data-toggle="tab">
                <asp:Label ID="Label60" runat="server" Text="Knowledge / Conhecimentos"></asp:Label></a></li>

        </ul>
        <!-- Tab panes -->
        <div class="tab-content" style="padding-top: 20px">
            <div role="tabpanel" class="tab-pane active" id="Occupation">
                <div class="row" style="padding: 20px">
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Developer general information /Informações gerais do desenvolvedor
                            </h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>

                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label>Email:*</label>

                                        <input type="text" class="form-control" id="txtEmail" runat="server" name="txtEmail" value="" />
                                         <asp:RequiredFieldValidator runat="server" id="req" controltovalidate="txtEmail" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Email!" />
                                    </div>
                                    <!-- /.form-group -->
                                    <div class="form-group">

                                        <label>Nome/Name:*</label>
                                        <input type="text" class="form-control" id="txtName" runat="server" name="txtName" value="" />
                                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtName" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Name / Nome!" />
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Skype: ( please create an account if you don't have yet / bom criar caso não tenha) *</label>
                                        <input type="text" class="form-control" id="txtSkype" runat="server" name="txtSkype" value="" />
                                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtSkype" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Skype" />
                                    </div>
                                    <!-- /.form-group -->
                                    <div class="form-group">
                                        <label>Telefone/Phone (Whatsapp):*</label>
                                        <input type="text" class="form-control" id="txtPhone" runat="server" />
                                       <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="txtPhone" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Telefone/Phone" />
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>LinkedIn:</label>
                                        <input type="text" class="form-control" id="txtLinkedIn" runat="server" name="txtLinkedIn" value="" />
                                        <label></label>
                                    </div>
                                    <!-- /.form-group -->
                                    <div class="form-group">
                                        <label>Cidade / City *</label>
                                        <input type="text" class="form-control" id="txtCity" runat="server" name="txtCity" value="" />
                                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="txtCity" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Cidade / City " />
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Estado/ State *</label>
                                        <input type="text" class="form-control" id="txtState" runat="server" name="txtState" value="" />
                                         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" controltovalidate="txtState" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Estado/ State " />
                                    </div>
                                    <!-- /.form-group -->
                                    <div class="form-group">
                                        <label>Portfolio</label>
                                        <input type="text" class="form-control" id="txtPortfolio" runat="server" name="txtPortfolio" value="" />
                                        
                                    </div>
                                    <!-- /.form-group -->
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>What is your hourly salary requirements? / Qual sua pretensão salarial por hora? *</label>
                                        <input type="text" class="form-control" id="txtSalary" runat="server" name="txtState" value="" />
                                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" controltovalidate="txtSalary" Font-Italic="true" ForeColor="Red"  errormessage="Please enter your Salary / Salarial " />
                                    </div>
                                    <!-- /.form-group -->

                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.box-body -->

                    </div>
                </div>


                <div class="row" style="padding: 10px">

                    <div class="col-md-6">
                        <div class="box box-success">
                            <div class="box-header">
                                <h3 class="box-title">What is your willingness to work today? / Qual é sua disponibilidade para trabalhar hoje? *</h3>
                            </div>
                            <div class="box-body">
                                <!-- Minimal style -->

                                <!-- checkbox -->
                                <div class="form-group">
                                    <asp:CheckBoxList ID="chkHours" runat="server" CssClass="form-group">
                                     
                                    </asp:CheckBoxList>

                                </div>



                            </div>
                            <!-- /.box-body -->

                        </div>
                        <!-- /.box -->


                    </div>

                    <div class="col-md-6">
                        <!-- iCheck -->
                        <div class="box box-success">
                            <div class="box-header">
                                <h3 class="box-title">What's the best time to work for you? / Pra você qual é o melhor horário para trabalhar?</h3>
                            </div>
                            <div class="box-body">

                                <div class="form-group">
                                    <asp:CheckBoxList ID="chkDayTime" runat="server" CssClass="form-group">

                                    </asp:CheckBoxList>

                                </div>

                            </div>
                            <!-- /.box-body -->

                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- /.col (right) -->
                </div>
                <!-- /.row -->

                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="btnNext" Text="Next" class="btn btn-primary btn-lg " OnClick="btnNext_Click" runat="server" />
                    </div>
                </div>
            </div>

            <div role="tabpanel" class="tab-pane" id="Knowledge">

                <div class="row" style="padding: 10px">

                    <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">Developer Knowledge / Conhecimento do desenvolvedor *</h3>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Skill/habilidade</label>

                                    <asp:DropDownList ID="cmbDevSkillCart" class="form-control select2" Style="width: 100%;" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class=" col-md-6">
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Nao conheco / I don't know &nbsp;</label>

                                    <asp:RadioButtonList ID="rdbExpertise" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbsp;  0 &nbsp; &nbsp;" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;  1 &nbsp; &nbsp;" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;  2 &nbsp; &nbsp;" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;  3 &nbsp; &nbsp;" Value="3" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;  4 &nbsp; &nbsp;" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;  5 &nbsp; &nbsp;" Value="5"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <label>&nbsp; Senior</label>
                                </div>
                            </div>
                            <div>
                                <asp:Button ID="btnAddSkill" Text="Add Skill" OnClick="btnAddSkill_Click" class="btn btn-primary btn-lg " runat="server" />
                            </div>

                        </div>

                        <!-- /.box-body -->

                    </div>
                    <!-- /.box -->



                </div>

                <div class="row" style="padding: 10px">

                    <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">Expertise</h3>
                        </div>
                        <div class="box-body">

                            <asp:GridView ID="grdDevSkills" class="table table-bordered table-striped" AutoGenerateColumns = False OnRowCommand="grdDevSkills_RowCommand" OnSelectedIndexChanged="grdDevSkills_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdDevSkills_PageIndexChanging" runat="server">
                                <Columns>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>

                                            <asp:Button ID="btnSkillSelect" CssClass="btn btn-info btn-sm upload-btn" runat="server" CausesValidation="false" CommandName="SelectSkill"
                                                Text="Select" CommandArgument='<%# Eval("SkillId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                                    <asp:BoundField DataField="Rating" HeaderText="Rating" />
                                   

                                </Columns>


                            </asp:GridView>


                        </div>
                        <!-- /.box-body -->

                    </div>
                    <!-- /.box -->



                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="btnSave" Text="Save" class="btn btn-primary btn-lg " OnClick="btnSave_Click" runat="server" />
                    </div>
                </div>

            </div>
        </div>


    </div>




    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>

</asp:Content>
