export type Endpoints = Record<string, Function>;

export namespace ExpenseTypesEndpoints {
    const base = '/api/v1';

    export const endpoints: Endpoints = {
        getAll: (apiUrl: string) => `${apiUrl}${base}/tipo-despesa`,
        create: (apiUrl: string) => `${apiUrl}${base}/tipo-despesa`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/tipo-despesa/${id}`,
        edit: (apiUrl: string, id: string) => `${apiUrl}${base}/tipo-despesa/${id}`
    };
}
