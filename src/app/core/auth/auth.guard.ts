import { inject } from "@angular/core";
import { CanActivateChildFn, CanActivateFn, Router } from "@angular/router";
import { AuthService } from "./auth.service";

export const AuthGuard: CanActivateFn | CanActivateChildFn = (route, state) => {
    const router = inject(Router);
    const authService = inject(AuthService)

    if (!authService.isAuthenticated()) {
        router.navigate(['login']);

        return false;
    }

    var routePermissions: string[] = route.data['permissions'];

    if (!routePermissions) {
        return true;
    }

    var userRoles: string[] = [];

    authService.membro$.subscribe(membro => {
        userRoles = membro?.permissoes || [];
    });

    if (routePermissions.some((element) => userRoles.includes(element))) {
        return true;
    }

    router.navigate(['permission-denied']);

    return false;
}