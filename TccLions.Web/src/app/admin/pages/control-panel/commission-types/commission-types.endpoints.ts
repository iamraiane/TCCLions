export type Endpoints = Record<string, Function>;

export namespace CommissionTypesEndpoints {
    const base = '/api/v1';

    export const endpoints: Endpoints = {
        getAll: (apiUrl: string) => `${apiUrl}${base}/tipoComissao`,
        create: (apiUrl: string) => `${apiUrl}${base}/tipoComissao`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/tipoComissao/${id}`,
        edit: (apiUrl: string, id: string) => `${apiUrl}${base}/tipoComissao/${id}`
    };
}
