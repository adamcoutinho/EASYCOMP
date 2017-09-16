<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Instrutor.aspx.cs" Inherits="Instrutor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="instrutor" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    Instrutor</h1>
                <div class="form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox id="txb_nome" class="form-control" runat="server" />
                    <p class="help-block">Escreva seu nome completo.</p>
                </div>
            </div><!-- Fim nome -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        RG</label>
                    <asp:TextBox id="txb_rg" class="form-control" runat="server" />
                    <p class="help-block">Escreva seu RG.</p>
                </div>
            </div><!-- Fim RG -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Telefone</label>
                    <asp:TextBox id="txb_telefone" class="form-control" runat="server" />
                    <p class="help-block">Escreva seu Telefone.</p>
                </div>
            </div><!-- Fim telefone -->
            <div class="col-md-4">
                <div class="form-group">
                    <label>
                        Data de nascimento</label>
                    <asp:TextBox id="txb_data_nascimento" class="form-control" runat="server" />
                    <p class="help-block">Escreva sua data de nascimento.</p>
                </div>
            </div><!-- Fim data de nascimento -->
            <div class="col-md-12">
                <div class="form-group">
                    <label>
                        Descrição</label>
                    <asp:TextBox id="txb_descricao" class="form-control" runat="server" />
                    <p class="help-block">Escreva uma descrição.</p>
                </div>
            </div><!-- Fim descrição -->
            <div class="col-md-12">
                <div class="form-group">
                    <label>
                        E-mail</label>
                    <asp:TextBox id="txb_email" class="form-control" runat="server" />
                    <p class="help-block">Escreva seu email.</p>
                </div>
            </div><!-- Fim e-mail -->
            <div class="col-md-12">
                <asp:Button ID="btn_salvar" class="btn btn-primary" Style="float: right; margin-right: 10px;" Text="Salvar" runat="server" OnClick="btn_salvar_Click" type="button" />
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btn_consultar" Style="float: right; margin-bottom: 35px; margin-top: 35px;" class="btn btn-warning" runat="server" Text="Pesquisar" OnClick="btn_consultar_Click" />
                <asp:GridView ID="grv_instrutor" class="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" OnRowDeleting="grv_instrutor_RowDeleting" OnRowEditing="grv_instrutor_RowEditing" DataKeyNames="ins_codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <%# Eval("ins_nome")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RG">
                            <ItemTemplate>
                                <%# Eval("ins_rg")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefone">
                            <ItemTemplate>
                                <%# Eval("ins_telefone")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data de nascimento">
                            <ItemTemplate>
                                <%# Eval("ins_data_nascimento")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descrição">
                            <ItemTemplate>
                                <%# Eval("ins_descricao")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-mail">
                            <ItemTemplate>
                                <%# Eval("ins_email")%>
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
            </div><!-- Fim Griview -->
        </div>
    </div>
    </form>
</asp:Content>
