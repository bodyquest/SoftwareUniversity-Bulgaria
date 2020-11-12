import {Router, RouterModule, Routes} from "@angular/router";
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
    {
        path: "",
        pathMatch: "full",
        component: HomeComponent
    },
    {
        path: "**",
        component: NotFoundComponent
    }

];

export const AppRoutingModule = RouterModule.forRoot(routes);