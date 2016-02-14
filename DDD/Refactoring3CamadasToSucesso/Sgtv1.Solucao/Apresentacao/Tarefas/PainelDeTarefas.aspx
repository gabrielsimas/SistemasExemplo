<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelDeTarefas.aspx.cs" Inherits="Apresentacao.Tarefas.PainelDeTarefas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel de Tarefas</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />        
</head>
<body>
    <div class="container">
        <form class="form-horizontal" role="form" runat="server">
            <fieldset>
                <legend>Painel de Tarefas do Usuário</legend>                
                <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#CadastroDeTarefaModal">Cadastrar Nova Tarefa</button>
                <br />
                <div class="panel panel-default" id="pnlTodasAsTarefas">
                    <div class="panel-heading"><asp:Label ID="lblTodasAsTarefas" Text="Todas as Tarefas Pendentes" runat="server"/></div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="gridTodasAsTarefas" runat="server"
                            AutoGenerateColumns="false" EmptyDataText="Não existem Tarefas pendentes."                            
                            CssClass="table" GridLines="None"
                                OnRowDataBound="gridTodasAsTarefas_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id"  />
                                <asp:BoundField DataField="Nome" HeaderText="Tarefa"/>
                                <asp:BoundField DataField="Descricao" HeaderText="Descri&ccedil;&atilde;o"/>
                                <asp:BoundField DataField="DataDeEntrega" DataFormatString="{0:d}" HeaderText="Prazo"/>  
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado01" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operações">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkExecutaTarefa" CommandArgument='<%#Bind("Id")%>' OnCommand="ExecutarTarefa" ToolTip="Executar a Tarefa">
                                            <span class="glyphicon glyphicon-ok" aria-hidden="true" />
                                            <br />                                            
                                        </asp:LinkButton>                                        
                                        <asp:LinkButton runat="server" ID="lnkEditar" CommandArgument='<%#Bind("Id")%>' OnClick="EditarTarefa" ToolTip="Edita a tarefa selecionada">
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true" />
                                            <br />
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lnkExcluir" CommandArgument='<%#Bind("Id")%>' OnClick="ExcluirTarefa" ToolTip="Exclui a tarefa">
                                            <span class="glyphicon glyphicon-trash" aria-hidden="true" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            </div><!-- table-responsive -->
                        </div><!-- panel-body -->
                </div>
                <div class="panel panel-warning" id="pnlTarefasAVencer">
                    <div class="panel-heading" id="pnlTarefasAVencerHeader">
                        <a data-toggle="collapse" href="#toggle01"><asp:Label ID="lblTarefasAVencer" Text="Tarefas à Vencer" runat="server"/></a>
                    </div>
                    <div id="toggle01" class="panel-collapse collapse">
                        <div class="panel-body" id="pnlTarefasAVencerBody">
                            <div class="table-responsive">
                            <asp:GridView ID="gridTarefasAVencer" runat="server"
                            AutoGenerateColumns="false" EmptyDataText="Não existem Tarefas à vencer."                            
                            CssClass="table" RowStyle-CssClass="warning" GridLines="None"
                                OnRowDataBound="gridTarefasAVencer_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Nome" HeaderText="Tarefa"/>
                                <asp:BoundField DataField="Descricao" HeaderText="Descri&ccedil;&atilde;o"/>
                                <asp:BoundField DataField="DataDeEntrega" DataFormatString="{0:d}" HeaderText="Prazo"/>  
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado02" />
                                    </ItemTemplate>
                                </asp:TemplateField>                                 
                            </Columns>
                        </asp:GridView>
                        </div>                        
                    </div>
                    </div>
                    
                </div>                
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        <a data-toggle="collapse" href="#toggle02"><asp:Label ID="lblTarefasVencidas" Text="Tarefas Vencidas" runat="server"/></a>
                    </div>
                    <div id="toggle02" class="panel-collapse collapse">                        
                        <div class="panel-body" id="pnlTarefasVencidasBody">
                        <div class="table-responsive">
                            <asp:GridView ID="gridTarefasVencidas" runat="server"
                            AutoGenerateColumns="false" EmptyDataText="Não existem Tarefas vencidas."
                            OnRowDataBound="gridTarefasVencidas_RowDataBound"                                                        
                            CssClass="table" RowStyle-CssClass="danger" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Nome" HeaderText="Tarefa"/>
                                <asp:BoundField DataField="Descricao" HeaderText="Descri&ccedil;&atilde;o"/>
                                <asp:BoundField DataField="DataDeEntrega" DataFormatString="{0:d}" HeaderText="Prazo"/>                                
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado03" />
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                 
                            </Columns>
                        </asp:GridView>
                        </div>
                    </div>
                    </div><!-- toggle02 -->
                </div>
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <a data-toggle="collapse" href="#toggle03"><asp:Label ID="lblTarefasExecutadas" Text="Tarefas Executadas" runat="server"/></a>
                    </div>
                    <div id="toggle03" class="panel-collapse collapse">
                        <div class="panel-body" id="pnlTarefasExecutadas">
							<div class="table-responsive">
								<asp:GridView ID="gridTarefasExecutadas" runat="server"
								AutoGenerateColumns="false" EmptyDataText="Não existem Tarefas executadas."  
								OnRowDataBound="gridTarefasExecutadas_RowDataBound"                                                      
								CssClass="table" RowStyle-CssClass="success" GridLines="None">
								<Columns>
									<asp:BoundField DataField="Id" HeaderText="Id" />
									<asp:BoundField DataField="Nome" HeaderText="Tarefa"/>
									<asp:BoundField DataField="Descricao" HeaderText="Descri&ccedil;&atilde;o"/>
									<asp:BoundField DataField="DataDeEntrega" DataFormatString="{0:d}" HeaderText="Prazo"/>                                
									<asp:TemplateField HeaderText="Estado">
										<ItemTemplate>
											<asp:Label runat="server" ID="lblEstado04" />
										</ItemTemplate>
									</asp:TemplateField>                                                                 
								</Columns>
							</asp:GridView>
							</div>
					    </div>
                    </div>
                </div>
                <!-- Modal -->
                <div id="CadastroDeTarefaModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span class="glyphicon glyphicon-off" />
                                </button>
                                <h4 class="modal-title">Modal Header</h4>
                            </div><!-- modal-header -->
                            <div class="modal-body">
                                <div class="panel-default">
                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2" runat="server" ID="lblTarefa" Text="Tarefa:" For="txtTarefa" />
                                        <div class="col-md-10">
                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Entre com o nome da Tarefa" ID="txtTarefa" />
                                        </div>                                        
                                    </div>
                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2"  runat="server" ID="lblDescricao" Text="Descri&ccedil;&atilde;o:" />
                                        <div class="col-md-10">
                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Entre com a descri&ccedil;&atilde;o" ID="txtDescricao" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2"  runat="server" ID="lblPrazo" Text="Prazo:" />
                                        <div class="col-md-10">
                                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Entre com a data para execu&ccedil;&atilde;o" ID="txtPrazo" TextMode="DateTime" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <!--<div class="col-md-offset-2 col-md-10">-->
                                            <asp:Button CssClass="btn btn-lg btn-primary btn-block" OnClick="CadastrarTarefa" runat="server" Text="Salvar"/>
                                        <!--</div>-->
                                    </div>
                                </div><!-- panel-default -->
                            </div> <!-- modal-header -->
                        </div> <!-- modal-content -->
                    </div>  <!-- modal-dialog -->
                </div> <!-- CadastroDeTarefaModal -->
            </fieldset>            
        </form>
    </div> <!-- Container -->
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery.maskedinput.js"></script>    
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/tarefas.js"></script>
</body>
</html>
