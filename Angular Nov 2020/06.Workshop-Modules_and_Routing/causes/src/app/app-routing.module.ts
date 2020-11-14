import {Router, RouterModule, Routes} from "@angular/router";
import { AuthGuard } from './auth.guard';
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
        component: LoginComponent,
        canActivate: [AuthGuard],
        data: {
            isLogged: false
        }
    },
    {
        path: "register",
        component: RegisterComponent,
        canActivate: [AuthGuard],
        data: {
            isLogged: false
        }
    },
    {
        path: "**",
        component: NotFoundComponent
    }

];

export const AppRoutingModule = RouterModule.forRoot(routes);