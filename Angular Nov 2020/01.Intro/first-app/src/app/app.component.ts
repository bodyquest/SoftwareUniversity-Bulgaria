import { Component, ChangeDetectionStrategy } from '@angular/core';

import { TodoService } from "./todo.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class AppComponent {
  title = 'Title: first-app';
  todoTitle = "Hello from TODO service!"

  visible = false;

  constructor(todoService: TodoService) {
    todoService.loadTodos();
  }

  toggleVisible() {
    this.visible = !this.visible;
  }

  users = [
    {
      name: "Ivancho",
      age: 10
    },
    {
      name: "Mariika",
      age: 11
    },
    {
      name: "Darincho",
      age: 38
    },
    {
      name: "Goshko",
      age: 40
    }
  ];

  deleteUserHandler(user) {
    this.users = this.users.filter(u => u !== user);
  }
}
