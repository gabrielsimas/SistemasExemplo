var aplicacao = angular.module('aplicacao', ['ngRoute']);

aplicacao.config
(
    function ($routeProvider) {

        //Mapeia cada rota da aplicação
        $routeProvider
            .when
            (
                '/inicio',
                {
                    templateUrl: "Angular/index.html",
                    controller: "index_Controller"
                }
            )
            .when
            (
                '/consulta',
                {
                    templateUrl: "Angular/consulta.html",
                    controller: "CategoriaController"
                }
            )
            .when
            (
                '/cadastro',
                {
                    templateUrl: "Angular/cadastro.html",
                    controller: "CategoriaController"
                }
            )

    }
);