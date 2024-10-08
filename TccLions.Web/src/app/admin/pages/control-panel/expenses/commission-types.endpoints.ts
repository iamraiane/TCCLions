export type Endpoints = Record<string, Function>;

export namespace CommissionTypesEndpoints {
    const base = '/api/v1';

    export const endpoints: Endpoints = {
        getAll: (apiUrl: string) => `${apiUrl}${base}/tipoComissao`,
    };
}
