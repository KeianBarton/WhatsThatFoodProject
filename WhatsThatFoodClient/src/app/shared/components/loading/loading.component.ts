import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { trigger, state, style, animate, transition, keyframes } from '@angular/animations';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css'],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        animate('1600ms ease-in', keyframes([
          style({opacity: 0, offset: 0}),
          style({opacity: 0, offset: 0.5}),
          style({opacity: 1, offset: 1})
        ]))
      ])
    ])
  ]
})
export class LoadingComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
  }

}
