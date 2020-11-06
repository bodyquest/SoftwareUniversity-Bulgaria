import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})

export class ArticleComponent implements OnInit {
  
  @Input() article: Article;

  private symbols: number = 250;
  visibleDescriptionLength: number = 0;
  showReadMoreBtn: boolean = true;
  showImage: boolean = false;

  get hasNoMoreInfo() {
    return this.description.length < this.visibleDescriptionLength;
  }

  get description() {
    return this.article.description.slice(0, this.visibleDescriptionLength)
  }

  constructor() { }

  toggleImage() {
    this.showImage = !this.showImage;
  }

  hideDescription() {
    this.visibleDescriptionLength = 0;
  }

  readMore() {
    if (this.description.length < this.visibleDescriptionLength) { return; }
    this.visibleDescriptionLength = this.visibleDescriptionLength + this.symbols;
  }

  ngOnInit(): void {
  }

}
