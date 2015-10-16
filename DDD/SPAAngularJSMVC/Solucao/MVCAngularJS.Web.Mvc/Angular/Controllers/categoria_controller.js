aplicacao.controller(
    'CategoriaController',
    function($scope,$http){
        
        //Inicializa Model
        $scope.CategoriaConsultaModel = {
            Id: '',
            Nome :''
        };

        $scope.CategoriaCadastroModel = {
            Id: '',
            Nome :''
        };

        $scope.CadastrarCategoria = function () {
            $scope.mensagem = "Aguarde... processando informação";

            $http.post("http://localhost:12108/Categoria/CadastrarCategoria", $scope.CategoriaCadastroModel)
                .success
                (
                    function (resposta) {
                        $scope.mensagem = msg.textoResposta;

                        //Limpar os campos
                        $scope.CategoriaCadastroModel.Nome = '';
                    }
                )
                .error(
                        function (e) {
                            $scope.mensagem = e; //imprimir..
                        }
                    );                
        };

        $scope.ConsultarPorId = function (id)
        {
            $http.get("http://localhost:12108/Categoria/BuscarCategoriaPorId/" + id)
                .success
                (
                    function (categoria) {
                        $scope.CategoriaConsultaModel.Id = categoria.Id;
                        $scope.CategoriaConsultaModel.Nome = categoria.Nome;
                    }
                )
                .error
                (
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        }

        $scope.ListarTodasAsCategorias = function()
        {
            $http.get("http://localhost:12108/Categoria/ListarTodasAsCategorias")
                .success
                (
                    function (resultado)
                    {
                        $scope.categorias = resultado;
                    }
                )
                .error(
                        function (e) {
                            $scope.mensagem = e;
                        }
                    );
        }

    });