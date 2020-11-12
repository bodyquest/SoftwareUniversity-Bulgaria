import {Router, RouterModule, Routes} from "@angular/router";

import { UserComponent } from './user.component';
import { ProfileComponent } from '../profile/profile.component';

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
                component: ProfileComponent
            }
        ]
    }
];

export const UserRoutingModule = RouterModule.forChild(routes);