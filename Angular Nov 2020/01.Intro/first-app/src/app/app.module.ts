import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import "@angular/compiler";
import { UserComponent } from './user/user.component';
import { TodoComponent } from './todo/todo.component';
import { TodoService } from './todo.service';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TodoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    TodoService,
    // {
         // if we want different instances of the service : useFactory
    //   provide: TodoService,
    //   useFactory: () => {
    //     return new TodoService();
    //   }
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
