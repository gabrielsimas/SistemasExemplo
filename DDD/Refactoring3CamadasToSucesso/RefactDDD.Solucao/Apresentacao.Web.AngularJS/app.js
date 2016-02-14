//Nome da Aplicação a ser abendada pelo AngularJS
var app = angular.module('tarefaAdm', ['ngRoute', 'ngResource']);

app.config(['$routeProvider',function ($routeProvider)
{    
    //Configuração de Rotas para o AngularJS
    $routeProvider
        .when(
            '/tarefa/lista',
            {
                templateUrl: "Views/listartarefa.html",
                controller: "TarefaCtrl"
            }
        )
        .when(
            '/tarefa/cadastro',
            {
                templateUrl: "Views/cadastrartarefa.html",
                controller: "TarefaCtrl"
            }
        );
}]);

