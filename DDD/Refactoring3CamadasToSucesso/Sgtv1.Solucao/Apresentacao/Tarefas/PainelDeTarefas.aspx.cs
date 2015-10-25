using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Tarefas;
using DAL.Entidades;

namespace Apresentacao.Tarefas
{
    public partial class PainelDeTarefas : System.Web.UI.Page
    {
        private NegocioTarefa negocio;
        private int idUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                gridTodasAsTarefasDataBind();
                gridTarefasAVencerDataBind();
                gridTarefasExecutadasDataBind();
                gridTarefasVencidasDataBind();
            }
        }

        protected void gridTodasAsTarefasDataBind()
        {
            idUsuario = Convert.ToInt16(Session["Usuario"].ToString());
            using (negocio = new NegocioTarefa())
            {
                ICollection<Tarefa> tarefas = negocio.ListarTarefasNaoConcluidas(idUsuario);
                if(tarefas != null && tarefas.Count > 0)
                {
                    gridTodasAsTarefas.DataSource = tarefas;
                    lblTodasAsTarefas.Text = "Tarefas à Vencer (" + tarefas.Count + ")";
                }else
                {
                    lblTodasAsTarefas.Text = "Tarefas à Vencer";
                    gridTodasAsTarefas.DataSource = null;

                }

                gridTodasAsTarefas.DataBind();
            }
        }

        protected void gridTarefasExecutadasDataBind()
        {
            idUsuario = Convert.ToInt16(Session["Usuario"].ToString());
            using (negocio = new NegocioTarefa())
            {
                ICollection<Tarefa> tarefas = negocio.ListarTarefasConcluidas(idUsuario);
                if(tarefas != null && tarefas.Count > 0)
                {
                    gridTarefasExecutadas.DataSource = tarefas;
                    lblTarefasExecutadas.Text = "Tarefas Executadas (" + tarefas.Count + ")";
                }else
                {
                    lblTarefasExecutadas.Text = "Tarefas Executadas";
                    gridTarefasExecutadas.DataSource = null;

                }

                gridTarefasExecutadas.DataBind();
            }
        }

        protected void gridTarefasVencidasDataBind()
        {
            idUsuario = Convert.ToInt16(Session["Usuario"].ToString());
            using (negocio = new NegocioTarefa())
            {
                ICollection<Tarefa> tarefas = negocio.ListarTarefasAtrasadas(idUsuario);
                if (tarefas != null && tarefas.Count > 0)
                {
                    gridTarefasVencidas.DataSource = tarefas;
                    lblTarefasVencidas.Text = "Tarefas Atrasadas (" + tarefas.Count + ")";
                }
                else
                {
                    lblTarefasVencidas.Text = "Tarefas Atrasadas";
                    gridTarefasVencidas.DataSource = null;

                }

                gridTarefasVencidas.DataBind();
            }
        }
        
        protected void gridTarefasAVencerDataBind()
        {
            idUsuario = Convert.ToInt16(Session["Usuario"].ToString());
            using(negocio = new NegocioTarefa())
            {
                ICollection<Tarefa> tarefas = negocio.ListarTarefasAVencer(idUsuario);
                if (tarefas != null && tarefas.Count > 0)
                {
                    gridTarefasAVencer.DataSource = tarefas;
                    lblTarefasAVencer.Text = lblTarefasAVencer.Text + " (" + tarefas.Count + ")";
                }
                else
                {
                    gridTarefasAVencer.DataSource = null;
                }
                
                gridTarefasAVencer.DataBind();
            }
        }
        
        protected void gridTarefasAVencer_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridTodasAsTarefas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado01");
                Tarefa tarefa;

                tarefa = (Tarefa)e.Row.DataItem;

                //No Prazo
                if (tarefa.DataDeEntrega >= DateTime.Now)
                {
                    e.Row.CssClass = "success";
                }
                else if(tarefa.DataDeEntrega < DateTime.Now)
                {
                    e.Row.CssClass = "danger";
                }

                if (tarefa.Estado == EstadoTarefa.EmAberto)
                {
                    lblEstado.Text = "Em Aberto";
                }
                else
                {
                    lblEstado.Text = "Executada";
                }               
            }
        }

        protected void gridTarefasAVencer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado02");
                Tarefa tarefa;

                tarefa =(Tarefa) e.Row.DataItem;
                
                if (tarefa.Estado == EstadoTarefa.EmAberto){
                    lblEstado.Text = "Em Aberto";
                }
                else
                {
                    lblEstado.Text = "Executada";
                }

            }
        }

        protected void gridTarefasVencidas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado03");
                Tarefa tarefa;

                tarefa = (Tarefa)e.Row.DataItem;

                if (tarefa.Estado == EstadoTarefa.EmAberto)
                {
                    lblEstado.Text = "Em Aberto";
                }
                else
                {
                    lblEstado.Text = "Executada";
                }
            }
        }

        protected void gridTarefasExecutadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado04");
                Tarefa tarefa;

                tarefa = (Tarefa)e.Row.DataItem;

                if (tarefa.Estado == EstadoTarefa.EmAberto)
                {
                    lblEstado.Text = "Em Aberto";
                }
                else
                {
                    lblEstado.Text = "Executada";
                }
            }
        }

        protected void EditarTarefa(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton) sender;            
            int idTarefa = Int32.Parse(btn.CommandArgument.ToString());

            using(negocio = new NegocioTarefa())
            {
               Tarefa tarefa = negocio.BuscarTarefaPorId(idTarefa);
                
            }

        }

        protected void ExcluirTarefa(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int idTarefa = Int32.Parse(btn.CommandArgument.ToString());
        }

        protected void ExecutarTarefa(object sender, CommandEventArgs e)
        {            
            int idTarefa = Int32.Parse(e.CommandArgument.ToString());
            using(negocio = new NegocioTarefa())
            {
                try
                {
                    negocio.MarcarTarefaComoConcluida(idTarefa);

                    gridTodasAsTarefasDataBind();
                    gridTarefasAVencerDataBind();
                    gridTarefasExecutadasDataBind();
                    gridTarefasVencidasDataBind();
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }

        protected void CadastrarTarefa(object sender, EventArgs e)
        {
            idUsuario = Convert.ToInt16(Session["Usuario"].ToString());

            if (String.IsNullOrEmpty(txtDescricao.Text) || String.IsNullOrEmpty(txtPrazo.Text) || String.IsNullOrEmpty(txtTarefa.Text) ){
                throw new Exception("É necessário que os 3 campos estejam preenchidos!");               
            }

            Tarefa tarefa = new Tarefa()
            {
                DataDeEntrega = DateTime.Parse(txtPrazo.Text),
                Descricao = txtDescricao.Text,
                Nome = txtTarefa.Text,
                IdUsuario = idUsuario
            };

            using(negocio = new NegocioTarefa())
            {
                negocio.CadastrarTarefa(tarefa);
            }

            gridTodasAsTarefasDataBind();
            gridTarefasAVencerDataBind();
            gridTarefasExecutadasDataBind();
            gridTarefasVencidasDataBind();
        }        
    }
}