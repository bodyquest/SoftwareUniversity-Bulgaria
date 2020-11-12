import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { DetailComponent } from './detail/detail.component';
import { CauseRoutingModule } from './create/cause-routing.module';



@NgModule({
  declarations: [CreateComponent, DetailComponent],
  imports: [
    CommonModule,
    CauseRoutingModule
  ],
  exports: [
    CreateComponent,
    DetailComponent
  ]
})
export class CauseModule { }
