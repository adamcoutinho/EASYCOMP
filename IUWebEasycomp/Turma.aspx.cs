using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Turma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDownList();
            //Turno
            ListItem Turno = new ListItem("", "0");
            Turno.Selected = true;
            ddl_turno.Items.Insert(ddl_turno.Items.Count, Turno);
            //Curso
            ListItem Curso = new ListItem("", "0");
            Curso.Selected = true;
            ddl_curso.Items.Insert(ddl_curso.Items.Count, Curso);
            //Instrutor
            ListItem Instrutor = new ListItem("", "0");
            Instrutor.Selected = true;
            ddl_instrutor.Items.Insert(ddl_instrutor.Items.Count, Instrutor);
            if (!IsPostBack)
            {
                ViewState.Add("tur_codigo", "");
            }
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        Turma_TO TurmaTO = new Turma_TO();

        try
        {
            TurmaTO.tur_nome = txb_nome_curso.Text;
            TurmaTO.tur_data_inicio = Convert.ToDateTime(txb_data_inicio.Text);
            TurmaTO.tur_turno = ddl_turno.SelectedValue;
            TurmaTO.tur_vagas = Convert.ToInt32(txb_quantidade_vagas.Text);
            //Instanciando Objeto dentro de um objeto
            TurmaTO.InstrutorTO = new Instrutor_TO();
            TurmaTO.InstrutorTO.ins_codigo = Convert.ToInt16(ddl_instrutor.SelectedValue);
            //Instanciando Objeto dentro de um objeto
            TurmaTO.CursoTO = new Curso_TO();
            TurmaTO.CursoTO.cur_codigo = Convert.ToInt16(ddl_curso.SelectedValue);

            bool novo = true;

            if (!string.IsNullOrEmpty(ViewState["tur_codigo"].ToString()))
            {
                TurmaTO.tur_codigo = Convert.ToInt32(ViewState["tur_codigo"]);
                novo = false;
            }

            if (new Turma_BO().Save(TurmaTO, novo))
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
    //Chamada do Gridview
    protected void btn_consultar_Click(object sender, EventArgs e)
    {
        LoadGridView();
    }
    protected void LoadGridView()
    {
        Turma_TO TurmaTO = new Turma_TO();

        try
        {
            List<Turma_TO> ListTurmaTO = new Turma_BO().SearchAll(TurmaTO);

            grv_turma.DataSource = ListTurmaTO;
            grv_turma.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_turma_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Turma_TO TurmaTO = new Turma_TO();

        try
        {
            TurmaTO.tur_codigo = Convert.ToInt32(grv_turma.DataKeys[e.RowIndex]["tur_codigo"]);

            new Turma_BO().Delete(TurmaTO);
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função editar no Gridview
    protected void grv_turma_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Turma_TO TurmaTO = new Turma_TO();
        try
        {
            TurmaTO.tur_codigo = Convert.ToInt32(grv_turma.DataKeys[e.NewEditIndex]["tur_codigo"]);
            TurmaTO = new Turma_BO().GetByCode(TurmaTO);

            ddl_turno.SelectedValue = TurmaTO.tur_turno;
            ddl_curso.SelectedValue = Convert.ToString(TurmaTO.CursoTO.cur_codigo);
            txb_quantidade_vagas.Text = Convert.ToString(TurmaTO.tur_vagas);
            ddl_instrutor.SelectedValue = Convert.ToString(TurmaTO.InstrutorTO.ins_codigo);
            txb_data_inicio.Text = Convert.ToString(TurmaTO.tur_data_inicio);
            txb_nome_curso.Text = Convert.ToString(TurmaTO.tur_nome);

            ViewState["tur_codigo"] = TurmaTO.tur_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //LoadDropdown List
    protected void LoadDropDownList()
    {
        //Curso
        Curso_TO CursoTO = new Curso_TO();
        //Intrutor
        Instrutor_TO InstrutorTO = new Instrutor_TO();

        try
        {
            //Lista Curso
            //List<Curso_TO> ListCursoTO = new Curso_BO().SearchAll(CursoTO);
            //ddl_curso.DataSource = ListCursoTO;
            //ddl_curso.DataValueField = "cur_codigo";
            //ddl_curso.DataTextField = "cur_nome";
            //ddl_curso.DataBind();
            //Lista Instrutor
            //List<Instrutor_TO> ListInstrutorTO = new Instrutor_BO().SearchAll(InstrutorTO);
            //ddl_instrutor.DataSource = ListInstrutorTO;
            //ddl_instrutor.DataValueField = "ins_codigo";
            //ddl_instrutor.DataTextField = "ins_nome";
            //ddl_instrutor.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btn_limpar_Click(object sender, EventArgs e)
    {
        Limpar();
    }
    //Metodo limpar
    private void Limpar()
    {
        txb_nome_curso.Text = "";
        ddl_turno.Text = "";
        ddl_curso.Text = "";
        txb_quantidade_vagas.Text = "";
        ddl_instrutor.Text = "";
        txb_data_inicio.Text = "";

        ViewState["tur_codigo"] = "";
    }
}