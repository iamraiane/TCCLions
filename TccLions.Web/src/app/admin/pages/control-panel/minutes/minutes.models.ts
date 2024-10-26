export interface Minute {
    id: string;
    titulo: string;
    descricao: string;
    dataEscrita: Date;
}

export type CreateMinute = {
    titulo: string;
    descricao: string;
    dataEscrita: Date;
}