import { Component } from '@angular/core';
import { ICause } from './shared/interfaces/cause';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'causes';
  selectedCause: ICause;
  selectCauseHandler(cause: ICause){
    this.selectedCause = cause;
  }
}