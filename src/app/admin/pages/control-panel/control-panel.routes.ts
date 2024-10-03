import { Routes } from "@angular/router";
import { MembersComponent } from "./members/members.component";
import { ComissionsComponent } from "./comissions/comissions.component";
import { ApplicationConstants } from "../../../core/settings/application-constants";
import { ExpensesComponent } from "./expenses/expenses.component";
import { CommissionTypesComponent } from "./commission-types/commission-types.component";
import { inject } from "@angular/core";
import { CommissionTypesService } from "./commission-types/commission-types.service";

export const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'members', component: MembersComponent, data: { permissions: [ApplicationConstants.permissions.Admin] } },
            { path: 'commissions', component: ComissionsComponent, data: { permissions: [ApplicationConstants.permissions.Admin] } },
            { path: 'expenses', component: ExpensesComponent, data: { permissions: [ApplicationConstants.permissions.Admin] } },
            {
                path: 'commission-types',
                component: CommissionTypesComponent,
                resolve: {
                    commissionTypes: () => inject(CommissionTypesService).getAll()
                },
                data: { permissions: [ApplicationConstants.permissions.Admin] }
            }
        ]
    }
]