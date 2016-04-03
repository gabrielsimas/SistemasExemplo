(function () {
	'use strict';

	angular.module('tarefaAdm')
		.config(['$routeProvider', configuraRotas]);

	function configuraRotas($routeProvider) {
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
	}
})();


