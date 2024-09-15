import { Routes } from "@angular/router";
import { MembersComponent } from "./members/members.component";
import { ComissionsComponent } from "./comissions/comissions.component";
import { ApplicationConstants } from "../../../core/settings/application-constants";

export const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'members', component: MembersComponent, data: { permissions: [ApplicationConstants.permissions.Admin] } },
            { path: 'commissions', component: ComissionsComponent, data: { permissions: [ApplicationConstants.permissions.Admin] } }
        ]
    }
]