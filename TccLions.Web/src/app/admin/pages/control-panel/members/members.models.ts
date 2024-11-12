export interface Member {
    id: string;
    nome: string;
    email: string;
    isActive: boolean;
}

export interface MemberDetails {
    nome: string;
    cpf: string;
    estadoCivil?: string;
    estadoCivilId?: number;
    email: string;
}

export type CreateMember = {
    nome: string;
    cpf: string;
    estadoCivilId: number;
    email: string;
    senha: string;
}