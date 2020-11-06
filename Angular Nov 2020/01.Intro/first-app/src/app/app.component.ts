import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'first-app';

  visible = false;

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
