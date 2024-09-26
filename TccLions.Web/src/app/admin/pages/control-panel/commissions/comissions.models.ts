export interface Comission {
    id: string;
    tipoComissao: string;
    nomeDoMembro: string;
}

export interface CreateCommission {
    tipoComissaoId: string;
    membroId: string;
}