export interface Member {
    id: string;
    nome: string;
    email: string;
    isActive: boolean;
}

export interface MemberDetails {
    nome: string;
    cpf: string;
    estadoCivil: number;
    email: string;
    cep: string;
    cidade: string;
    bairro: string;
    endereco: string;
}

export type CreateMember = {
    nome: string;
    cpf: string;
    estadoCivil: number;
    email: string;
    cep: string;
    cidade: string;
    bairro: string;
    endereco: string;
}