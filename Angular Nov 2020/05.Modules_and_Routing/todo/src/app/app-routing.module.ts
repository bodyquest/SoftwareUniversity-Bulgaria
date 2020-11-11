import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent as TodoListComponent} from './todo/list/list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "todo"
  },
  {
    path: "todo", 
    children: [
      {
        path: "",
        pathMatch: "full",
        redirectTo: "/todo/list"
      },
      {
        path: "list",
        component: TodoListComponent
      }
    ]
  },
  {
    path: "**",
    component: NotFoundComponent
  }
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }

export const AppRoutingModule = RouterModule.forRoot(routes);