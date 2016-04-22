
var express = require('express');

//Cria a nossa aplicação utilizando o Express
var aplicacao = express();

//Mongoose para o MongoDB
var mongoose = require('mongoose');

//Envio de logs para o console com Morgan
var morgan = require('morgan');

//Envia informações via HTML POST
var bodyParser = require('body-parser');

//Simula os métodos HTTP PUT e DELETE
var methodOverride = require('method-override');

//Configuração

//Conectando-se ao Mongo via Mongoose no modulus.io
// connect to mongoDB database on modulus.io

//mongoose.connect('mongodb://node:nodeuser@localhost/senha');
mongoose.connect('mongodb://node:nodeuser@mongo.onmodulus.net:27017/uwO3mypu');

// set the static files location /public/img will be /img for users
// Configure o local para os arquivos estáticos /public/img para /img para os usuários e urls
aplicacao.use(express.static(__dirname + '/Publico'));

//Manda tudo pro console
aplicacao.use(morgan('dev'));

//faz um parse através da codificação application/x-www-form-urlencoded
aplicacao.use(bodyParser.urlencoded({'extended':'true'}));

//faz um parse de application/json
aplicacao.use(bodyParser.json());

//faz um parse de application/vnd.api+json para json 
aplicacao.use(bodyParser.json({type: 'application/vnd.api+json'}));

aplicacao.use(methodOverride());

//Modelos da aplicação através do Mongoose
var Tarefa = mongoose.model('Tarefa',{
	texto: String,
	executada: Boolean
	});


//Rotas ===============================================================================================

//API

//GET todas as tarefas
aplicacao.get('/api/tarefas',pegaTodasAsTarefas);

// Cria uma tarefa e como resposta devolve todas as tarefas criadas
aplicacao.post('/api/tarefas',criaTarefa);

//Apaga uma tarefa
aplicacao.delete('/api/tarefas/:tarefa_id',apagaTarefa);

//AngularJS
aplicacao.get('*',paginaInicialAngular);



function pegaTodasAsTarefas(requisicao,resposta){	

	Tarefa.find(findAll);	

	function findAll(erro,tarefas){
	if (erro){
			resposta.send(erro);
		}	
		
	resposta.json(tarefas);
	}
}

function criaTarefa(requisicao,resposta){

	var tarefaModel = {
		text: requisicao.body.texto,
		done: false
	};

	Tarefa.create(tarefaModel,create);

	function create(erro,tarefa){
		if (erro) resposta.send(erro)
		resposta.json(tarefa);
	}

	pegaTodasAsTarefas;
	
}

function apagaTarefa(requisicao,resposta){

	var tarefaModel = {
		_id: requisicao.params.todo_id
	}

	Tarefa.remove(tarefaModel,erase);

	function erase(erro,tarefa){
		if(erro){
			resposta.send(erro);
		}
	}

	pegaTodasAsTarefas;
}

function paginaInicialAngular(requisicao,resposta){	
	// carrega uma única view em nosso caso (o angular irá gerenciar as alterações)
	resposta.sendfile('.Publico/index.html'); 

}
//Inicio do servidor com a aplicação
aplicacao.listen(9900);
console.log("Gerenciado de Tarefas rodando na porta 9900");
