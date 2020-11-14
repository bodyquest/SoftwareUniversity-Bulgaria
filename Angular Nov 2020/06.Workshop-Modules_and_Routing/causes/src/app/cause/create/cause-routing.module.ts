import {Router, RouterModule, Routes} from "@angular/router";
import { AuthGuard } from 'src/app/auth.guard';
import { DetailComponent } from '../detail/detail.component';
import { CreateComponent } from './create.component';

const routes: Routes = [
    {
        path: "cause",
        children: [
            {
                path: "",
                pathMatch: "full",
                redirectTo: "/cause/create"
            },
            {
                path: "create",
                component: CreateComponent,
                canActivate: [AuthGuard],
                data: {
                    isLogged: true
                }
            },
            {
                path: "detail/:id",
                component: DetailComponent,
                canActivate: [AuthGuard],
                data: { 
                    shouldFetchCause: true,
                    isLogged: true
                }
            }
        ]
    }
];

export const CauseRoutingModule = RouterModule.forChild(routes);