using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;

public partial class Turma_Programacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {  
            ViewState.Add("tpr_codigo", "");
            LoadDropDownTurma();       
        }      
        
    }
    protected void LoadDropDownTurma()
    {
        try
        {
            ddl_turma.DataSource = new Turma_BO().SearchAll(new Turma_TO());
            ddl_turma.DataValueField = "tur_codigo";
            ddl_turma.DataTextField = "tur_nome";
            ddl_turma.DataBind();
            ddl_turma.Items.Insert(0, "");  
        }
        catch (Exception ex)
        {
            lbl_msg.Text = ex.Message;
        }
    }
    //Botão salvar
    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        TurmaProgramacao_TO TurmaProgramacaoTO = new TurmaProgramacao_TO();
        TurmaProgramacaoTO.TurmaTO = new Turma_TO();

        try
        {
            TurmaProgramacaoTO.tpr_data_aula = Convert.ToDateTime(txb_data.Text);
            TurmaProgramacaoTO.tpr_horas_inicial = txb_hora_inicio.Text;
            TurmaProgramacaoTO.tpr_horas_final = txb_hora_final.Text;
            TurmaProgramacaoTO.TurmaTO.tur_codigo = Convert.ToInt32(ddl_turma.SelectedValue);

            bool novo = true;

            if (!string.IsNullOrEmpty(ViewState["tpr_codigo"].ToString()))
            {
                TurmaProgramacaoTO.tpr_codigo = Convert.ToInt32(ViewState["tpr_codigo"]);
                novo = false;
            }

            if (new TurmaProgramacao_BO().Save(TurmaProgramacaoTO, novo))
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
    //Função editar no Gridview
    protected void grv_tpr_programacao_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TurmaProgramacao_TO TurmaProgramacaoTO = new TurmaProgramacao_TO();

        try
        {
            TurmaProgramacaoTO.tpr_codigo = Convert.ToInt32(grv_tpr_programacao.DataKeys[e.NewEditIndex]["tpr_codigo"]);

            TurmaProgramacaoTO = new TurmaProgramacao_BO().GetByCode(TurmaProgramacaoTO);

            ddl_turma.SelectedValue = Convert.ToString(TurmaProgramacaoTO.TurmaTO.tur_codigo);
            txb_data.Text = Convert.ToString(TurmaProgramacaoTO.tpr_data_aula);
            txb_hora_inicio.Text = TurmaProgramacaoTO.tpr_horas_inicial;
            txb_hora_final.Text = TurmaProgramacaoTO.tpr_horas_final;
            LoadGridView();
            ViewState["tpr_codigo"] = TurmaProgramacaoTO.tpr_codigo;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Função deletar no Gridview
    protected void grv_tpr_programacao_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TurmaProgramacao_TO TurmaProgramacaoTO = new TurmaProgramacao_TO();

        try
        {
            TurmaProgramacaoTO.tpr_codigo = Convert.ToInt32(grv_tpr_programacao.DataKeys[e.RowIndex]["tpr_codigo"]);

            new TurmaProgramacao_BO().Delete(TurmaProgramacaoTO);
            LoadGridView();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Metodo limpar
    private void Limpar()
    {
        ddl_turma.SelectedIndex = 0;
        txb_data.Text = "";
        txb_hora_inicio.Text = "";
        txb_hora_final.Text = "";
    }
    //Chamada do Gridview
    protected void btn_consultar_Click(object sender, EventArgs e)
    {
        LoadGridView();
    }
    protected void LoadGridView()
    {
        TurmaProgramacao_TO TurmaProgramacaoTO = new TurmaProgramacao_TO();

        try
        {
            List<TurmaProgramacao_TO> ListTurmaProgramacaoTO = new TurmaProgramacao_BO().SearchAll(TurmaProgramacaoTO);
            Turma_TO TurmaTO = new Turma_TO();

            grv_tpr_programacao.DataSource = ListTurmaProgramacaoTO;
            grv_tpr_programacao.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
}