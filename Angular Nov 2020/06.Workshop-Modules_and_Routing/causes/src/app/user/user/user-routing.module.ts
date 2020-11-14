import {Router, RouterModule, Routes} from "@angular/router";

import { UserComponent } from './user.component';
import { ProfileComponent } from '../profile/profile.component';
import { AuthGuard } from 'src/app/auth.guard';

const routes: Routes = [
    {
        path: "user",
        children: [
            {
                path: "",
                pathMatch: "full",
                component: UserComponent
            },
            {
                path: "profile",
                component: ProfileComponent,
                canActivate: [AuthGuard],
                data: {
                    isLogged: true
                }
            }
        ]
    }
];

export const UserRoutingModule = RouterModule.forChild(routes);