export type Endpoints = Record<string, Function>;

export namespace MembersEndpoints {

    const base = '/api/v1';

    export const endpoints: Endpoints = {
        get: (apiUrl: string) => `${apiUrl}${base}/membro`,
    };
}
