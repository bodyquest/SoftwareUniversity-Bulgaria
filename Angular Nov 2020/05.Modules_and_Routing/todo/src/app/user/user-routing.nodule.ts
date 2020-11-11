import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from '../auth.guard';
import { UserResolver } from './user.resolver';

const routes: Routes = [
//   {
    // path: "user",
    // canActivate: [AuthGuard],
    // data: {
    //     roles: ["admin"]
    // },
    // children: [
      {
        path: "",
        pathMatch: "full",
        redirectTo: "list"
      },
      {
        path: "list",
        resolve: {
            userList: UserResolver
        },
        component: ListComponent
      },
      {
        path: ":id",
        component: UserComponent
      }
//   ]
//   }
]; 

export const UserRoutingModule = RouterModule.forChild(routes);