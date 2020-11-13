import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CausesService } from 'src/app/causes.service';
import { ICause } from 'src/app/shared/interfaces/cause';

@Component({
  selector: 'app-cause-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {

  @ViewChild("inputAmount", {static: false}) inputAmount: ElementRef<HTMLInputElement>;
  @Input() selectedCause2: ICause;

  get selectedCause() {
    return this.causesService.selectedCause;
  }

  get color() {
    if (this.selectedCause.collectedAmount >= this.selectedCause.neededAmount) {
      return "green";
    }
    if(
      this.selectedCause.collectedAmount < 2* (this.selectedCause.neededAmount/3) &&
      this.selectedCause.collectedAmount > this.selectedCause.neededAmount/3) {
      return "yellow";
    }

    return "red";
  }

  constructor(
    private causesService: CausesService,
    private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit() {
    if(this.activatedRoute.snapshot.params.id){
      this.causesService
        .load(+this.activatedRoute.snapshot.params.id)
        .subscribe(() => {
          this.causesService.selectCause(this.causesService.causes[0]);
        });
    }
  }

  makeDonationHandler() {
    this.causesService
      .donate(+this.inputAmount.nativeElement.value)
      .subscribe(() => { 
      this.causesService.load();
      this.inputAmount.nativeElement.value = "";
    });
  }
}
