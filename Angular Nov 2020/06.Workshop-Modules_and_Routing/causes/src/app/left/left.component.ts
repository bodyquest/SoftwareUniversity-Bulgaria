import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CausesService } from '../causes.service';
import { ICause } from '../shared/interfaces/cause';

@Component({
  selector: 'app-left',
  templateUrl: './left.component.html',
  styleUrls: ['./left.component.scss']
})
export class LeftComponent implements OnInit {

  get causes() {
    return this.causesService.causes;
  }

  // @Output() selectCause: EventEmitter<ICause> = new EventEmitter();
  
  constructor(private causesService: CausesService) { }

  ngOnInit() {
    this.causesService.loadCauses();
  }

  selectCauseHandler(cause: ICause) {
    // this.selectCause.emit(cause);
    this.causesService.selectedCause = cause;
  }
}
