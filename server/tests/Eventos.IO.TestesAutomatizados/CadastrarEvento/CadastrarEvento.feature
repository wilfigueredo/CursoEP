Funcionalidade: Adicionar novo Evento
	Um Organizador fará seu login pelo site
	e seguirá para a área administrativa
	onde registrará um novo evento

@TesteAutomatizadoCadastroNovoEvento

Cenário: Registro de Novo Evento
	Dado que o Organizador está no site
	E Realiza o Login
	E Navega até a area administrativa
	E Clica em novo evento
	E preenche o formulário com os valores 
		| Campo									| Valor                                |
		| nome									| DevXperience                         |
		| descricaoCurta						| Um novo evento de tecnologia         |
		| descricaoLonga						| Um novo evento de tecnologia         |
		| categoriaId							| 1bbfa7e9-5a1f-4cef-b209-58954303dfc3 |
		| //*[@id="dataInicio"]/div/div/input   | 20/10/2019						   |
		| //*[@id="dataFim"]/div/div/input		| 22/10/2019                           |
		| gratuito								| false                                |
		| valor									| 1.578,87                             |
		| online								| false                                |
		| nomeEmpresa							| DevX                                 |
		| logradouro							| Av. Reboucas                         |
		| numero								| 600								   |
		| complemento							| 3 andar							   |
		| bairro								| Pinheiros							   |
		| cep									| 05402000							   |
		| cidade								| São Paulo							   |
		| estado								| SP								   |
	Quando clicar no botao adicionar
	Entao O evento é registrado e o usuario redirecionado para a lista de eventos

