export class Evento {
    id: string;
    nome: string;
    descricaoCurta: string;
    descricaoLonga: string;
    dataInicio: Date;
    dataFim: Date;
    gratuito: boolean;
    valor: string;
    online: boolean;
    nomeEmpresa: string;
    endereco: Endereco;
    categoriaId: string;
    organizadorId: string;
}

export class Endereco {
    id: string;
    logradouro: string;
    numero: string;
    complemento: string;
    bairro: string;
    cep: string;
    cidade: string;
    estado: string;
    eventoId: string;
}

export interface Categoria {
    id: string;
    nome: string;
}