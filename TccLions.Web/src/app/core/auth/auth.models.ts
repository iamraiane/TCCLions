export type AuthResponse = {
    token: string;
    membro: MembroAuthResponse;
};

export type MembroAuthResponse = {
    name: string;
    email: string;
    permissoes: [{ nome: string }];
};

