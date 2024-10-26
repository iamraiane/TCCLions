export type Endpoints = Record<string, Function>;

export namespace MinutesEndpoints {
    const base = '/api/v1';

    export const endpoints: Endpoints = {
        get: (apiUrl: string) => `${apiUrl}${base}/ata`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/ata/${id}`,
        create: (apiUrl: string) => `${apiUrl}${base}/ata`,
        getById: (apiUrl: string, id: string) => `${apiUrl}${base}/ata/${id}`,
    };
}