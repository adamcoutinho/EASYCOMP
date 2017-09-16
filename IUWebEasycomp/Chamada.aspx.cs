using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Chamada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDownList();
        }
        //DataBind atual
        data.Text = "<strong>Data atual: </strong>" + DateTime.Now.ToShortDateString();
    }
    //LoadDropdown List
    protected void LoadDropDownList()
    {
        //Curso
        Turma_TO TurmaTO = new Turma_TO();
        try
        {
            //Lista Curso
            //List<Turma_TO> ListTurmaTO = new Turma_BO().SearchAll(TurmaTO);
            //ddl_turma.DataSource = ListTurmaTO;
            //ddl_turma.DataValueField = "tur_codigo";
            //ddl_turma.DataTextField = "tur_nome";
            //ddl_turma.DataBind();
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
        Chamada_TO ChamadaTO = new Chamada_TO();
        ChamadaTO.MatriculaTO = new Matricula_TO();
        ChamadaTO.MatriculaTO.TurmaTO = new Turma_TO();
        ChamadaTO.MatriculaTO.TurmaTO.tur_codigo = Convert.ToInt32(ddl_turma.SelectedValue);
        try
        {
            List<Chamada_TO> ListChamadaTO = new Chamada_BO().SearchAll(ChamadaTO);

            grv_chamada.DataSource = ListChamadaTO;
            grv_chamada.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grv_chamada.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("ckb_presenca");

                Chamada_TO ChamadaTO = new Chamada_TO();
                ChamadaTO.MatriculaTO = (Matricula_TO)grv_chamada.DataKeys[row.RowIndex]["MatriculaTO"];
                ChamadaTO.TurmaProgramacaoTO = (TurmaProgramacao_TO)grv_chamada.DataKeys[row.RowIndex]["TurmaProgramacaoTO"];

                ChamadaTO.cha_presenca = checkBox.Checked ? 1 : 0;

                if (new Chamada_BO().Update(ChamadaTO))
                {
                    lbl_msg.Text = "Salvo";
                }
            }
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "Erro desconhecido: " + ex.Message;
        }
    }
}