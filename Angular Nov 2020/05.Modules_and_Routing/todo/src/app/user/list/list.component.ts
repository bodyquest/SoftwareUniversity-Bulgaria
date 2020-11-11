import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  users: any[];

  constructor(
    private userService: UserService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.users = activatedRoute.snapshot.data.userList;
  }

  ngOnInit() {
    this.userService.loadUser()
    .pipe(delay(2000))
    .subscribe(users => this.users = users);
  }

  selectUserHandler(userId: number) {
    this.router.navigate(["/user", userId]);
  }
}
