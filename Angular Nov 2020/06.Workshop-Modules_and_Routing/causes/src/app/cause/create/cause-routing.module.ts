import {Router, RouterModule, Routes} from "@angular/router";
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
                component: CreateComponent
            },
            {
                path: "detail/:id",
                component: DetailComponent
            }
        ]
    }
];

export const CauseRoutingModule = RouterModule.forChild(routes);