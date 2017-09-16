<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Turma_Programacao.aspx.cs" Inherits="Turma_Programacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="trm_programacao" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        Turmas</label>
                    <asp:DropDownList class="form-control" ID="ddl_turma" runat="server">
                    </asp:DropDownList>
                    <p class="help-block">
                        Selecione a turma.</p>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        Data</label>
                    <asp:TextBox ID="txb_data" class="form-control" runat="server" />
                    <p class="help-block">
                        Data da aula.</p>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        Hora Ínicio</label>
                    <asp:TextBox ID="txb_hora_inicio" class="form-control" runat="server" />
                    <p class="help-block">
                        Horário de ínicio.</p>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>
                        Hora Fim</label>
                    <asp:TextBox ID="txb_hora_final" class="form-control" runat="server" />
                    <p class="help-block">
                        Horário de fim.</p>
                </div>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btn_salvar" class="btn btn-primary" Style="float: right; margin-right: 10px;"
                    Text="Salvar" runat="server" OnClick="btn_salvar_Click" />
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            </div><!-- Fim btn salvar -->
            <div class="col-md-12">
                <asp:Button ID="btn_consultar" Style="float: right; margin-bottom: 35px; margin-top: 35px;" class="btn btn-warning"
                    runat="server" Text="Pesquisar" OnClick="btn_consultar_Click" />
            </div><!-- Fim btn consultar -->
            <div class="col-md-12">
                <asp:GridView ID="grv_tpr_programacao" OnRowDeleting="grv_tpr_programacao_RowDeleting" OnRowEditing="grv_tpr_programacao_RowEditing" class="table table-striped table-bordered table-hover"
                    runat="server" AutoGenerateColumns="false" DataKeyNames="tpr_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Curso">
                            <ItemTemplate>
                                <%# Eval("TurmaTO.CursoTO.cur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turma">
                            <ItemTemplate>
                                <%# Eval("TurmaTO.tur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data da aula">
                            <ItemTemplate>
                                <%# string.Format("{0:dd/MM/yyyy}", Eval("tpr_data_aula")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Horário de ínicio">
                            <ItemTemplate>
                                <%# Eval("tpr_horas_inicial")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Horário de fim">
                            <ItemTemplate>
                                <%# Eval("tpr_horas_final")%>
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
            </div><!-- Fim gridview -->
        </div>
    </div>
    </form>
</asp:Content>
