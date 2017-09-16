<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Turma.aspx.cs" Inherits="Turma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="turma" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    Turmas</h1>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox class="form-control" type="text" name="txb_nome_curso" ID="txb_nome_curso"
                        runat="server" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>
                        Turno</label>
                    <asp:DropDownList ID="ddl_turno" class="form-control" runat="server">
                        <asp:ListItem Text="Manhã" />
                        <asp:ListItem Text="Tarde" />
                        <asp:ListItem Text="Noite" />
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Fim select -->
            <div class="col-md-3">
                <div class="form-group">
                    <label>
                        Curso</label>
                    <asp:DropDownList ID="ddl_curso" runat="server" class="form-control">
                    </asp:DropDownList>
                    <!-- Fim dropdown turno -->
                </div>
            </div>
            <!-- Fim div -->
            <div class="col-md-3">
                <div class="form-group">
                    <label>
                        Quantidade de vagas</label>
                    <asp:TextBox class="form-control" type="text" name="txb_quantidade_vagas" ID="txb_quantidade_vagas"
                        size="10" MaxLength="10" runat="server" />
                </div>
            </div>
            <!-- Fim calendario -->
            <div class="col-md-8">
                <div class="form-group">
                    <label>
                        Intrutor</label>
                    <asp:DropDownList ID="ddl_instrutor" runat="server" class="form-control">
                    </asp:DropDownList>
                    <!-- Fim dropdown turno -->
                </div>
            </div>
            <!-- Fim div -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Data de Inicio</label>
                    <asp:TextBox class="form-control" type="text" name="txb_data_inicio" ID="txb_data_inicio"
                        runat="server" />
                </div>
            </div>
            <!-- Fim calendario -->
            <div class="col-md-12">
                <asp:Button ID="btn_limpar" type="reset" OnClick="btn_limpar_Click" class="btn btn-default" Style="float: right;"
                    Text="Limpar" runat="server" />
                <asp:Button ID="btn_salvar" class="btn btn-primary" Style="float: right; margin-right: 10px;"
                    Text="Salvar" runat="server" OnClick="btn_salvar_Click" />
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btn_consulta" OnClick="btn_consultar_Click" type="reset" class="btn btn-warning"
                    Style="float: right; margin-top: 15px; margin-bottom: 15px;" Text="Consultar"
                    runat="server" />
            </div>
            <!-- Fim btn consultar -->
            <div class="col-md-12">
                <asp:GridView ID="grv_turma" class="table table-striped table-bordered table-hover"
                    runat="server" AutoGenerateColumns="false" OnRowDeleting="grv_turma_RowDeleting"
                    OnRowEditing="grv_turma_RowEditing" DataKeyNames="tur_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Instrutor">
                            <ItemTemplate>
                                <%# Eval("InstrutorTO.ins_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nome do curso">
                            <ItemTemplate>
                                <%# Eval("tur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Curso">
                            <ItemTemplate>
                                <%# Eval("CursoTO.cur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turno">
                            <ItemTemplate>
                                <%# Eval("tur_turno")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data inicio">
                            <ItemTemplate>
                                <%# Eval("tur_data_inicio")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantidade de vagas">
                            <ItemTemplate>
                                <%# Eval("tur_vagas")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success fa fa-pencil"
                            CommandName="Edit" HeaderText="Editar" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger fa fa-trash-o"
                            CommandName="Delete" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>
                <style type="text/css">
                    .btn-success, .btn-danger
                    {
                        width: 100%;
                    }
                </style>
            </div>
            <!-- Fim gridview -->
        </div>
    </div>
    </form>
</asp:Content>
