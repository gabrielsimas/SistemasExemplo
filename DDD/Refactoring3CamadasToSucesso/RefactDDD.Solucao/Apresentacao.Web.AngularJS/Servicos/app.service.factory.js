(function () {
    'use strict';

    angular.module('tarefaAdm')
        .factory('TarefaAPI', ['$resource', tarefaServico]);

    function tarefaServico($resource)
    {
        return $resource("http://localhost:3371/v1/tarefa", {}, {
            get: { method: 'GET', isArray: true },
            save: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' },
            patch: { method: 'PATCH' }
        });
    }    
})();