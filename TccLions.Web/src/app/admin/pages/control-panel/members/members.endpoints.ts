export type Endpoints = Record<string, Function>;

export namespace MembersEndpoints {

    const base = '/api/v1';

    export const endpoints: Endpoints = {
        get: (apiUrl: string) => `${apiUrl}${base}/membro`,
        getDetails: (apiUrl: string, id: string) => `${apiUrl}${base}/membro/${id}`,
        register: (apiUrl: string) => `${apiUrl}${base}/auth/register`,
        update: (apiUrl: string, id: string) => `${apiUrl}${base}/membro/${id}`,
        delete: (apiUrl: string, id: string) => `${apiUrl}${base}/membro/${id}`,
        disable: (apiUrl: string, id: string) => `${apiUrl}${base}/membro/${id}/disable`,
        enable: (apiUrl: string, id: string) => `${apiUrl}${base}/membro/${id}/enable`
    };
}
