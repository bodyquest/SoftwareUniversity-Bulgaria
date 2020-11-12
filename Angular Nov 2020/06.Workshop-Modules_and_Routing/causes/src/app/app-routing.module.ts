import {Router, RouterModule, Routes} from "@angular/router";
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
    {
        path: "",
        pathMatch: "full",
        component: HomeComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "register",
        component: RegisterComponent
    },
    {
        path: "**",
        component: NotFoundComponent
    }

];

export const AppRoutingModule = RouterModule.forRoot(routes);