(function () {
    'use strict';
    angular.module('tarefaAdm')
        .controller('TarefaCtrl', ['$scope', 'TarefaAPI', tarefaController]);

    tarefaController.$inject = ['$scope', 'TarefaAPI'];

    function tarefaController($scope, TarefaAPI) {

        var vm = this;

        vm.Listar = listarTarefa;
        
        function listarTarefa() {
            
            TarefaAPI.get({ idUsuario: 9, tipoBusca: 0, dataInicio: null, dataTermino: null },
                    function (response) {                    
                            console.log("Sucesso: " + JSON.stringify(response));
                            vm.Tarefas = response;                    
                    }                
                , 
                    function (errorResponse) {
                        console.log("Erro:" + JSON.stringify(errorResponse));
                    }
                );                       
        }        
    }    
})();