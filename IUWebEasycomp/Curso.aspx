<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Curso.aspx.cs" Inherits="Curso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="curso" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        Curso</h1>
                    <div class="form-group">
                        <label>
                            Nome</label>
                        <asp:TextBox ID="txb_nome" class="form-control" runat="server" />
                        <p class="help-block">
                            Escreve o nome do curso completo.</p>
                    </div>
                </div><!-- Fim nome -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>
                            Descrição</label>
                        <asp:TextBox ID="txb_descricao" class="form-control" runat="server" />
                        <p class="help-block">Escreve a descrição.</p>
                    </div>
                </div>
                <!-- Fim descrição -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>
                            Duração</label>
                        <asp:TextBox ID="txb_duracao" class="form-control" runat="server" />
                        <p class="help-block">Escreve a duração do curso.</p>
                    </div>
                </div>
                <!-- Fim duração -->
                <div class="col-md-12">
                    <asp:Button ID="btn_salvar" class="btn btn-primary" Style="float: right; margin-right: 10px;" Text="Salvar" runat="server" OnClick="btn_salvar_Click" />
                    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                </div><!-- Fim botão salvar -->
                <div class="col-md-12">
                <h1>
                    Lista de cursos</h1>
                    <asp:Button ID="btn_consultar" Style="float: right; margin-bottom: 35px;" class="btn btn-warning" runat="server" Text="Pesquisar" OnClick="btn_consultar_Click" />
                </div><!-- Fim botão consultar -->
                <div class="col-md-12">
                <asp:GridView ID="grv_cursos" class="table table-striped table-bordered table-hover"
                    runat="server" AutoGenerateColumns="false" OnRowDeleting="grv_cursos_RowDeleting" OnRowEditing="grv_cursos_RowEditing" DataKeyNames="cur_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <%# Eval("cur_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descrição">
                            <ItemTemplate>
                                <%# Eval("cur_descricao")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duração">
                            <ItemTemplate>
                                <%# Eval("cur_duracao")%>
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

