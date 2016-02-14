app.controller(
    'TarefaCtrl',['$scope','TarefaAPI',
    function ($scope,TarefaAPI) {

        $scope.Listar = function () {
            TarefaAPI.get({ idUsuario: 9, tipoBusca: 0, dataInicio: null, dataTermino: null },
                function success(response) {
                    console.log("Sucesso: " + JSON.stringify(response));
                    $scope.Tarefas = response;
                },
                function error(errorResponse) {
                    console.log("Erro:" + JSON.stringify(errorResponse));
                }
            );
        }
            

    }
]);