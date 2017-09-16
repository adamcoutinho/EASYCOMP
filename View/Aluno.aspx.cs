using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

namespace View
{
    public partial class Aluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                AlunoTO.alu_dara_nascimento = Convert.ToDateTime(txb_data_nascimento.Text);
                AlunoTO.alu_endereco = txb_endereco.Text;
                AlunoTO.alu_cpf = Convert.ToString(txb_cpf.Text);
                AlunoTO.alu_email = txb_email.Text;
                if (new Aluno_BO().Save(AlunoTO, true))
                {
                    lbl_msg.Text = "Salvo com sucesso!";
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
        //Gridview
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
        protected void grv_alunos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Aluno_TO AlunoTO = new Aluno_TO();

            try
            {
                AlunoTO.alu_codigo = Convert.ToInt32(grv_aluno.DataKeys[e.RowIndex]["alu_codigo"]);

                new Aluno_BO().Delete(AlunoTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}