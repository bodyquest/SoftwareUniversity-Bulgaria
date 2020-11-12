import { Component, ElementRef, Input, OnInit, Output, ViewChild } from '@angular/core';
import { CausesService } from '../causes.service';
import { ICause } from '../shared/interfaces/cause';

@Component({
  selector: 'app-right',
  templateUrl: './right.component.html',
  styleUrls: ['./right.component.scss']
})
export class RightComponent implements OnInit {

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

  constructor(private causesService: CausesService) { }

  ngOnInit(): void {
  }

  makeDonationHandler() {
    this.causesService
      .donate(+this.inputAmount.nativeElement.value)
      .subscribe(() => { 
      this.causesService.loadCauses();
      this.inputAmount.nativeElement.value = "";
    });
  }
}
