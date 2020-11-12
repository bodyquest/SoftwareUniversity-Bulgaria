import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { ProfileComponent } from './profile/profile.component';



@NgModule({
  declarations: [UserComponent, ProfileComponent],
  imports: [
    CommonModule
  ]
})
export class UserModule { }
