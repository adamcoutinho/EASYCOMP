using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Aluno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState.Add("alu_codigo", "");
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        Aluno_TO AlunoTO = new Aluno_TO();
        try
        {
            AlunoTO.alu_nome = txb_nome.Text;
            AlunoTO.alu_bairro = txb_bairro.Text;
            AlunoTO.alu_telefone = Convert.ToInt32(txb_telefone.Text);
            AlunoTO.alu_data_nascimento = Convert.ToDateTime(txb_data_nascimento.Text);
            AlunoTO.alu_endereco = txb_endereco.Text;
            AlunoTO.alu_cpf = Convert.ToString(txb_cpf.Text);
            AlunoTO.alu_email = txb_email.Text;

            bool novo = true;

            if (!string.IsNullOrEmpty(ViewState["alu_codigo"].ToString()))
            {
                AlunoTO.alu_codigo = Convert.ToInt32(ViewState["alu_codigo"]);
                novo = false;
            }

            if (new Aluno_BO().Save(AlunoTO, novo))
            {
                lbl_msg.Text = novo ? "Salvo com sucesso!" : "Atualizado com sucesso!";

                Limpar();
                LoadGridView();
            }
            else
            {
                lbl_msg.Text = "Não salvou.";
            }
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "Erro desconhecido: " + ex.Message;
        }
    }
    //Botão de limpar
    protected void btn_limpar_Click(object sender, EventArgs e)
    {
        Limpar();
    }
    //Metodo limpar
    private void Limpar()
    {
        txb_nome.Text = "";
        txb_bairro.Text = "";
        txb_telefone.Text = "";
        txb_data_nascimento.Text = "";
        txb_endereco.Text = "";
        txb_cpf.Text = "";
        txb_email.Text = "";

        ViewState["alu_codigo"] = "";
    }
    //Chamada do Gridview
    protected void btn_consultar_Click(object sender, EventArgs e)
    {
        LoadGridView();
    }
    protected void LoadGridView()
    {
        Aluno_TO AlunoTO = new Aluno_TO();

        try
        {
            List<Aluno_TO> ListAlunoTO = new Aluno_BO().SearchAll(AlunoTO);

            grv_aluno.DataSource = ListAlunoTO;
            grv_aluno.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_alunos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Aluno_TO AlunoTO = new Aluno_TO();

        try
        {
            AlunoTO.alu_codigo = Convert.ToInt32(grv_aluno.DataKeys[e.RowIndex]["alu_codigo"]);

            new Aluno_BO().Delete(AlunoTO);
            Limpar();
            LoadGridView();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função editar no Gridview
    protected void grv_alunos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Aluno_TO AlunoTO = new Aluno_TO();

        try
        {
            AlunoTO.alu_codigo = Convert.ToInt32(grv_aluno.DataKeys[e.NewEditIndex]["alu_codigo"]);

            AlunoTO = new Aluno_BO().GetByCode(AlunoTO);

            txb_nome.Text = AlunoTO.alu_nome;
            txb_bairro.Text = AlunoTO.alu_bairro;
            txb_telefone.Text = Convert.ToString(AlunoTO.alu_telefone);
            txb_data_nascimento.Text = AlunoTO.alu_data_nascimento.ToShortDateString();
            txb_endereco.Text = AlunoTO.alu_endereco;
            txb_cpf.Text = AlunoTO.alu_cpf;
            txb_email.Text = AlunoTO.alu_email;

            ViewState["alu_codigo"] = AlunoTO.alu_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
}