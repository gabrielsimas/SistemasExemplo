# Refactoring de um Sistema em 3 camadas para um Sistema com DDD
Um sistema gerenciador de tarefas há muito desatualizado com 3 camadas, sem tipos genéricos, sem Injeção de dependências e sem uma divisão específicas entre as camadas.

O que a aplicação têm:
- EF com Code First
- Sem Genéricos
- Autenticação de Usuários no padrão MD5 puro apenas com confronto entre a senha o hash que está no Banco
- WebForms
- Camadas sobrepostas causando uma grande confusão no código.

