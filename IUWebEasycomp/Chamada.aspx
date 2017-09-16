<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Chamada.aspx.cs" Inherits="Chamada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="turma" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>Tela de Chamada</h1>
                    <asp:Label ID="data" runat="server"></asp:Label>
                    <style type="text/css">
                        #ContentPlaceHolder1_data
                        {
                            color: Black;
                            margin-top: 10px;
                            margin-bottom: 10px;
                            font-family: @Arial Unicode MS;
                            font-size: 16px;
                            font-weight: lighter;
                            float: right;
                        }
                    </style>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>
                            Turma</label>
                        <asp:DropDownList ID="ddl_turma" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:Button Text="Consultar" class="btn btn-warning" Onclick="btn_consultar_Click" style="margin-top: 15px;" runat="server" />
                    </div>
                </div>
                <div class="col-md-10">
                    <asp:GridView ID="grv_chamada" class="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" DataKeyNames="MatriculaTO, TurmaProgramacaoTO">
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <%# Eval("MatriculaTO.AlunoTO.alu_nome")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Presença">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckb_presenca" runat="server" />             
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btn_salvar" Text="Salvar" class="btn btn-primary" Onclick="btn_salvar_Click" style="margin-top: 15px;" runat="server" />
                    <style type="text/css">
                        .btn-success, .btn-danger
                        {
                            width: 100%;
                        }
                    </style>
                </div><!-- Fim gridview -->
                <div class="col-md-12">
                    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

