export type AuthResponse = {
    token: string;
    membro: MembroAuthResponse;
};

export type MembroAuthResponse = {
    nome: string;
    email: string;
    permissoes: string[];
};
