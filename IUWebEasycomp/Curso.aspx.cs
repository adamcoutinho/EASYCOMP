using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Curso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState.Add("cur_codigo", "");
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        Curso_TO CursoTO = new Curso_TO();
        try
        {
            CursoTO.cur_nome = txb_nome.Text;
            CursoTO.cur_duracao = Convert.ToInt32(txb_duracao.Text);
            CursoTO.cur_descricao = txb_descricao.Text;

            bool novo = true;

            if (!string.IsNullOrEmpty(ViewState["cur_codigo"].ToString()))
            {
                CursoTO.cur_codigo = Convert.ToInt32(ViewState["cur_codigo"]);
                novo = false;
            }

            if (new Curso_BO().Save(CursoTO, novo))
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
        txb_descricao.Text = "";
        txb_duracao.Text = "";

        ViewState["cur_codigo"] = "";
    }
    //Chamada do Gridview
    protected void btn_consultar_Click(object sender, EventArgs e)
    {
        LoadGridView();
    }
    protected void LoadGridView()
    {
        Curso_TO CursoTO = new Curso_TO();

        try
        {
            List<Curso_TO> ListCursoTO = new Curso_BO().SearchAll(CursoTO);

            grv_cursos.DataSource = ListCursoTO;
            grv_cursos.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_cursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Curso_TO CursoTO = new Curso_TO();

        try
        {
            CursoTO.cur_codigo = Convert.ToInt32(grv_cursos.DataKeys[e.RowIndex]["cur_codigo"]);

            new Curso_BO().Delete(CursoTO);
            Limpar();
            LoadGridView();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função editar no Gridview
    protected void grv_cursos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Curso_TO CursoTO = new Curso_TO();

        try
        {
            CursoTO.cur_codigo = Convert.ToInt32(grv_cursos.DataKeys[e.NewEditIndex]["cur_codigo"]);

            CursoTO = new Curso_BO().GetByCode(CursoTO);

            txb_nome.Text = CursoTO.cur_nome;
            txb_descricao.Text = CursoTO.cur_descricao;
            txb_duracao.Text = Convert.ToString(CursoTO.cur_duracao);
            ViewState["cur_codigo"] = CursoTO.cur_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
}