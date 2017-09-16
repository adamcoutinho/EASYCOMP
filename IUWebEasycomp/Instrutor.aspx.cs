using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Instrutor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState.Add("ins_codigo", "");
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        Instrutor_TO InstrutorTO = new Instrutor_TO();
        try
        {

            InstrutorTO.ins_nome = txb_nome.Text;
            InstrutorTO.ins_rg = Convert.ToInt32(txb_rg.Text);
            InstrutorTO.ins_telefone = Convert.ToInt32(txb_telefone.Text);
            InstrutorTO.ins_data_nascimento = Convert.ToDateTime(txb_data_nascimento.Text);
            InstrutorTO.ins_descricao = txb_descricao.Text;
            InstrutorTO.ins_email = txb_email.Text;

            bool novo = true;
            if (!string.IsNullOrEmpty(ViewState["ins_codigo"].ToString()))
            {
                InstrutorTO.ins_codigo = Convert.ToInt32(ViewState["ins_codigo"]);
                novo = false;
            }

            if (new Instrutor_BO().Save(InstrutorTO, novo))
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
    //Metodo limpar
    private void Limpar()
    {
        txb_nome.Text = "";
        txb_rg.Text = "";
        txb_telefone.Text = "";
        txb_data_nascimento.Text = "";
        txb_descricao.Text = "";
        txb_email.Text = "";

        ViewState["ins_codigo"] = "";
    }
    //Função editar no Gridview
    protected void grv_instrutor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Instrutor_TO InstrutorTO = new Instrutor_TO();

        try
        {
            InstrutorTO.ins_codigo = Convert.ToInt32(grv_instrutor.DataKeys[e.NewEditIndex]["ins_codigo"]);

            InstrutorTO = new Instrutor_BO().GetByCode(InstrutorTO);

            txb_nome.Text = InstrutorTO.ins_nome;
            txb_rg.Text = Convert.ToString(InstrutorTO.ins_rg);
            txb_telefone.Text = Convert.ToString(InstrutorTO.ins_telefone);
            txb_data_nascimento.Text = InstrutorTO.ins_data_nascimento.ToShortDateString();
            txb_descricao.Text = InstrutorTO.ins_descricao;
            txb_email.Text = InstrutorTO.ins_email;

            ViewState["ins_codigo"] = InstrutorTO.ins_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_instrutor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Instrutor_TO InstrutorTO = new Instrutor_TO();

        try
        {
            InstrutorTO.ins_codigo = Convert.ToInt32(grv_instrutor.DataKeys[e.RowIndex]["ins_codigo"]);

            new Instrutor_BO().Delete(InstrutorTO);
            Limpar();
            LoadGridView();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Chamada do Gridview
    protected void btn_consultar_Click(object sender, EventArgs e)
    {
        LoadGridView();
    }
    protected void LoadGridView()
    {
        Instrutor_TO InstrutorTO = new Instrutor_TO();

        try
        {
            List<Instrutor_TO> ListInstrutorTO = new Instrutor_BO().SearchAll(InstrutorTO);

            grv_instrutor.DataSource = ListInstrutorTO;
            grv_instrutor.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
}