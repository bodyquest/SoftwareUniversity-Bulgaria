import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  user: any;
  constructor(
    private userService: UserService,
    private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit() {
    let userId = this.activatedRoute.snapshot.params.id;
    this.userService.loadUser(userId)
      .pipe(delay(2000))
      .subscribe(user => this.user = user);
  }

}
