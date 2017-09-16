<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Matricula.aspx.cs" Inherits="Matricula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="matricula" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    Cadastrar Matrícula</h1>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Aluno</label>
                    <asp:DropDownList ID="ddl_aluno" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Curso</label>
                    <asp:DropDownList ID="ddl_curso" runat="server" class="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_curso_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Nome da Turma</label>
                    <asp:DropDownList ID="ddl_turma" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12">
                <asp:Button ID="Button1" Text="Salvar" class="btn btn-primary" style="float:right;" OnClick="btn_salvar_Click" runat="server" />
            </div>
            <div class="col-md-12">
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Button Text="Consultar" OnClick="btn_consultar_Click" class="btn btn-warning" style="float:right; margin-top: 15px; margin-bottom: 15px;" runat="server" />
            </div>
            <div class="col-md-12">
                <asp:GridView ID="grv_matricula" class="table table-striped table-bordered table-hover" OnRowEditing="grv_matricula_RowEditing" OnRowDeleting="grv_matricula_RowDeleting"
                    runat="server" AutoGenerateColumns="false" DataKeyNames="mat_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Aluno">
                            <ItemTemplate>
                                <%# Eval("AlunoTO.alu_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data de cadastro">
                            <ItemTemplate>
                                <%# Eval("mat_data_matricula")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turma">
                            <ItemTemplate>
                                <%# Eval("TurmaTO.tur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success fa fa-pencil" CommandName="Edit" HeaderText="Editar" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger fa fa-trash-o" CommandName="Delete" HeaderText="Excluir" />
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
