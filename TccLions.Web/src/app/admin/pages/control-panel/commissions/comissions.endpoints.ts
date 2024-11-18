export type Endpoints = Record<string, Function>;

export namespace ComissionsEndpoints {

    const base = '/api/v1';

    export const endpoints: Endpoints = {
        get: (apiUrl: string) => `${apiUrl}${base}/comissao`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/comissao/${id}`,
        create: (apiUrl: string) => `${apiUrl}${base}/comissao`,
        edit: (apiUrl: string, id: string) => `${apiUrl}${base}/comissao/${id}`,
    };
}
