import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { DetailComponent } from './detail/detail.component';
import { CauseRoutingModule } from './create/cause-routing.module';
import { ListComponent } from './list/list.component';



@NgModule({
  declarations: [CreateComponent, DetailComponent, ListComponent],
  imports: [
    CommonModule,
    CauseRoutingModule
  ],
  exports: [
    CreateComponent,
    DetailComponent,
    ListComponent
  ]
})
export class CauseModule { }
