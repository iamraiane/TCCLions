export interface Expense {
    id: string;
    nome: string;
    despesas: MemberExpenses[];
}

export interface MemberExpenses {
    id: string;
    dataVencimento: string;
    valorTotal: number;
    dataRegistro: string;
    tipoDeDespesa: string;
}