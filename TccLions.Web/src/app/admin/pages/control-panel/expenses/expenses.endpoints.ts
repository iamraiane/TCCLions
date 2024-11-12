export type Endpoints = Record<string, Function>;

export namespace ExpensesEndpoints {
    const base = '/api/v1';

    export const endpoints: Endpoints = {
        get: (apiUrl: string) => `${apiUrl}${base}/despesas`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/despesas/${id}`,
        create: (apiUrl: string) => `${apiUrl}${base}/despesas`
    };
}