<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Aluno.aspx.cs"
    Inherits="View.Aluno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Aluno</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="aluno" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    Aluno</h1>
                <div class="form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox ID="txb_nome" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu nome completo.</p>
                </div>
            </div>
            <!-- Fim nome -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Bairro</label>
                    <asp:TextBox ID="txb_bairro" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu bairro.</p>
                </div>
            </div>
            <!-- Fim bairro -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Telefone</label>
                    <asp:TextBox ID="txb_telefone" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu telefone.</p>
                </div>
            </div>
            <!-- Fim telefone -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Data de nascimento</label>
                    <asp:TextBox ID="txb_data_nascimento" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve sua data de nascimento.</p>
                </div>
            </div>
            <!-- Fim data nascimento -->
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        Endereço</label>
                    <asp:TextBox ID="txb_endereco" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu endereço.</p>
                </div>
            </div>
            <!-- Fim endereço -->
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        CPF</label>
                    <asp:TextBox ID="txb_cpf" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu CPF.</p>
                </div>
            </div>
            <!-- Fim CPF -->
            <div class="col-md-12">
                <div class="form-group">
                    <label>
                        E-mail</label>
                    <asp:TextBox ID="txb_email" class="form-control" runat="server" />
                    <p class="help-block">
                        Escreve seu e-mail.</p>
                </div>
            </div>
            <!-- Fim e-mail -->
            <div class="col-md-12">
                <asp:Button ID="btn_salvar" class="btn btn-primary" Style="float: right;" Text="Salvar"
                    runat="server" OnClick="btn_salvar_Click" />
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <h1>
                    Lista de alunos</h1>
                <asp:Button ID="btn_consultar" Style="float: right; margin-bottom: 35px;" class="btn btn-warning"
                    runat="server" Text="Pesquisar" OnClick="btn_consultar_Click" />
            </div>
            <!-- Fim btn consultar -->
            <div class="col-md-12">
                <asp:GridView ID="grv_aluno" class="table table-striped table-bordered table-hover"
                    runat="server" AutoGenerateColumns="false" OnRowDeleting="grv_alunos_RowDeleting"
                    DataKeyNames="alu_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <%# Eval("alu_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bairro">
                            <ItemTemplate>
                                <%# Eval("alu_bairro")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefone">
                            <ItemTemplate>
                                <%# Eval("alu_telefone")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data de nascimento">
                            <ItemTemplate>
                                <%# Eval("alu_dara_nascimento")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Endereço">
                            <ItemTemplate>
                                <%# Eval("alu_endereco")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CPF">
                            <ItemTemplate>
                                <%# Eval("alu_cpf")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <%# Eval("alu_email")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success fa fa-pencil"
                            CommandName="Delete" HeaderText="Editar" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger fa fa-trash-o"
                            CommandName="Delete" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>
            </div>
            <!-- Fim gridview -->
            <!-- Ajuste na largura do botão. Para 100% -->
            <style type="text/css">
                .btn-success, .btn-danger
                {
                    width: 100%;
                }
            </style>
        </div>
    </div>
    </form>
    <!-- Fim aluno -->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"
        integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"
        crossorigin="anonymous"></script>
</asp:Content>
