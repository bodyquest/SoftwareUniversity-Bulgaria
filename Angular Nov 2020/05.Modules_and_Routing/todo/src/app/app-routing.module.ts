import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent as UserListComponent} from './user/list/list.component';
import { ListComponent as TodoListComponent} from './todo/list/list.component';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    component: TodoListComponent
  },
  {
    path: "user",
    component: UserListComponent
  }
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }

export const AppRoutingModule = RouterModule.forRoot(routes);