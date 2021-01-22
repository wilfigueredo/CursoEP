Funcionalidade: Cadastro de Organizador
	Um organizador fará seu cadastro pelo site
	para poder gerenciar seus próprios eventos
	Ao terminar o cadastro receberá uma notificação
	de sucesso ou de falha.

@TesteAutomatizadoCadastroDeOrganizadorComSucesso

Cenário: Cadastro de Organizador com Sucesso
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor                       |
		| nome             | Eduardo Pires               |
		| cpf              | 30390600822                 |
		| email            | contato@eduardopires.net.br |
		| senha            | Teste@123                   |
		| senhaConfirmacao | Teste@123                   |	
	Quando clicar no botao registrar
	Então Será registrado e redirecionado com sucesso
	
@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com CPF já utilizado
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						   |
		| nome             | Eduardo Pires				   |
		| cpf              | 30390600822				   |
		| email            | contato12@eduardopires.net.br |
		| senha            | Teste@123                     |
		| senhaConfirmacao | Teste@123                     |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de CPF já cadastrado

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Email já utilizado
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600821					  |
		| email            | contato@eduardopires.net.br |
		| senha            | Teste@123                     |
		| senhaConfirmacao | Teste@123                     |
	Quando clicar no botao registrar
	Entao recebe uma mensagem de erro de email já cadastrado

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Senha sem números
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | Teste@                        |
		| senhaConfirmacao | Teste@                        |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de que a senha requer numero

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Senha sem Maiuscula
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | teste@123                     |
		| senhaConfirmacao | teste@123                     |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de que a senha requer letra maiuscula

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Senha sem minuscula
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | TESTE@123                     |
		| senhaConfirmacao | TESTE@123                     |
	Quando clicar no botao registrar		
	Entao Recebe uma mensagem de erro de que a senha requer letra minuscula

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Senha sem caracter especial
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | Teste123                      |
		| senhaConfirmacao | Teste123                      |
	Quando clicar no botao registrar		
	Entao Recebe uma mensagem de erro de que a senha requer caracter especial

@TesteAutomatizadoCadastroOrganizadorFalha
		
Cenário: Cadastro de Organizador com Senha em tamanho inferior ao permitido
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | Te123                         |
		| senhaConfirmacao | Te123                         |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de que a senha esta em tamanho inferior ao permitido

@TesteAutomatizadoCadastroOrganizadorFalha

Cenário: Cadastro de Organizador com Senha diferentes
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor						  |
		| nome             | Eduardo Pires				  |
		| cpf              | 30390600822					  |
		| email            | contato@eduardopires.net.br |
		| senha            | Teste@123                     |
		| senhaConfirmacao | Teste@124                     |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro de que a senha estao diferentes