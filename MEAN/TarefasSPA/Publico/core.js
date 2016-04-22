var appTarefa = angular.module('appTarefa',[]);

function principalController($scope,$http){

	$scope.formData = {};

	//Quando carregar a página, pega todas as tarefas cadastradas
	$http.get('http://localhost:9900/api/tarefas/')
		.success(function(dado){
			$scope.tarefas = dado;
			console.log(dado);
		})
		.error(function(dado){
			console.log('Erro: ' + dado);
		});
	
	// Quando enviar os valor pelo formulário de cadastro, envia os dados para a API do node
	$scope.criarTarefa = function(){

		$http.post('/api/tarefas/',$scope.formData)
			.success(function(dado){
				$scope.formData = {}; // limpa o formuláro para que possa se entrar outra tarefa depois
				$scope.tarefas = dado;
				console.log(dado);
			})
			.error(function(dado){
				console.log('Erro: ' + dado);
			})
	};

	//Apaga uma tarefa após verificar sua existência
	$scope.apagarTarefa = function(id){
		$http.delete('/api/tarefas' + id)
			.success(function(data){
				$scope.tarefas = dado;
				console.log(dado);
			})
			.error(function(dado){
				console.log('Erro: ' + dado);
			})
	};

}