using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Matricula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadDropDownListCurso();
            //LoadDropDownListAluno();
            ////Aluno
            //ListItem Aluno = new ListItem("", "0");
            //Aluno.Selected = true;
            //ddl_aluno.Items.Insert(ddl_aluno.Items.Count, Aluno);
            ////Curso
            //ListItem Curso = new ListItem("", "0");
            //Curso.Selected = true;
            //ddl_curso.Items.Insert(ddl_aluno.Items.Count, Aluno);
            //if (!IsPostBack)
            //{
            //    ViewState.Add("mat_codigo", "");
            //}
        }
    }
    //LoadDropdown List
    protected void LoadDropDownListCurso()
    {
        //Curso_TO CursoTO = new Curso_TO();

        //try
        //{
        //    //Lista Aluno
        //    List<Curso_TO> ListCursoTO = new Curso_BO().SearchAll(CursoTO);
        //    ddl_curso.DataSource = ListCursoTO;
        //    ddl_curso.DataValueField = "cur_codigo";
        //    ddl_curso.DataTextField = "cur_nome";
        //    ddl_curso.DataBind();
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
    }
    //LoadDropdown List
    protected void LoadDropDownListAluno()
    {
        //Curso

    }
    //LoadDropdown List
    protected void LoadDropDownListTurma(int pCurso)
    {
        //Turma_TO TurmaTO = new Turma_TO();
        //TurmaTO.CursoTO = new Curso_TO();

        //try
        //{
        //    TurmaTO.CursoTO.cur_codigo = pCurso;
        //    List<Turma_TO> ListTurmaTO = new Turma_BO().SearchAll(TurmaTO);
        //    ddl_turma.DataSource = ListTurmaTO;
        //    ddl_turma.DataValueField = "tur_codigo";
        //    ddl_turma.DataTextField = "tur_nome";
        //    ddl_turma.DataBind();
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
    }
    //Botão Salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        Matricula_TO MatriculaTO = new Matricula_TO();
        MatriculaTO.AlunoTO = new Aluno_TO();
        MatriculaTO.TurmaTO = new Turma_TO();

        try
        {
            MatriculaTO.mat_data_matricula = DateTime.Now;
            MatriculaTO.AlunoTO.alu_codigo = Convert.ToInt16(ddl_aluno.SelectedValue);
            MatriculaTO.TurmaTO.tur_codigo = Convert.ToInt16(ddl_turma.SelectedValue);

            bool novo = true;

            if (!string.IsNullOrEmpty(ViewState["mat_codigo"].ToString()))
            {
                MatriculaTO.mat_codigo = Convert.ToInt32(ViewState["mat_codigo"]);
                novo = false;
            }

            if (new Matricula_BO().Save(MatriculaTO, novo))
            {
                lbl_msg.Text = novo ? "Salvo com sucesso!" : "Atualizado com sucesso!";

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
        Matricula_TO MatriculaTO = new Matricula_TO();

        try
        {
            List<Matricula_TO> ListMatriculaTO = new Matricula_BO().SearchAll(MatriculaTO);

            grv_matricula.DataSource = ListMatriculaTO;
            grv_matricula.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função editar no Gridview
    protected void grv_matricula_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Matricula_TO MatriculaTO = new Matricula_TO();

        try
        {
            MatriculaTO.mat_codigo = Convert.ToInt32(grv_matricula.DataKeys[e.NewEditIndex]["mat_codigo"]);
            MatriculaTO = new Matricula_BO().GetByCode(MatriculaTO);

            ddl_aluno.SelectedValue = Convert.ToString(MatriculaTO.AlunoTO.alu_codigo);
            ddl_curso.SelectedValue = Convert.ToString(MatriculaTO.TurmaTO.CursoTO.cur_codigo);
            LoadDropDownListTurma(MatriculaTO.TurmaTO.CursoTO.cur_codigo);
            ddl_turma.SelectedValue = Convert.ToString(MatriculaTO.TurmaTO.tur_codigo);

            ViewState["mat_codigo"] = MatriculaTO.mat_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_matricula_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Matricula_TO MatriculaTO = new Matricula_TO();

        try
        {
            MatriculaTO.mat_codigo = Convert.ToInt32(grv_matricula.DataKeys[e.RowIndex]["mat_codigo"]);

            new Matricula_BO().Delete(MatriculaTO);
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void ddl_curso_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int codigo = int.Parse(ddl_curso.SelectedValue);
            LoadDropDownListTurma(codigo);
        }
        catch (Exception)
        {
            throw;
        }
    }
}