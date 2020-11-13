import { Component, OnInit } from '@angular/core';
import { CausesService } from 'src/app/causes.service';
import { ICause } from 'src/app/shared/interfaces/cause';

@Component({
  selector: 'app-cause-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  get causes() {
    return this.causesService.causes;
  }

  // @Output() selectCause: EventEmitter<ICause> = new EventEmitter();
  
  constructor(private causesService: CausesService) { }

  ngOnInit() {
    this.causesService.load().subscribe();
  }

  selectCauseHandler(cause: ICause) {
    // this.selectCause.emit(cause);
    this.causesService.selectCause(cause);
  }
}
