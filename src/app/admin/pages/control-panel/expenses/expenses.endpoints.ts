export type Endpoints = Record<string, Function>;

export namespace ExpensesEndPoints {
    const base = '/api/v1';

    export const endpoints: Endpoints ={
        get: (apiUrl: string) => `${apiUrl}${base}/despesa`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/despesa/${id}`
    };
}