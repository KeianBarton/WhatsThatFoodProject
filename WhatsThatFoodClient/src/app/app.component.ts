import { Component } from '@angular/core';
import { trigger, state, style, animate, transition, keyframes } from '@angular/animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        animate('500ms ease-out', keyframes([
          style({opacity: 0, offset: 0}),
          style({opacity: 1, offset: 1})
        ]))
      ]),
    ]),
    trigger('bounceInFromTop', [
      transition(':enter', [
        animate('500ms ease-out', keyframes([
          style({opacity: 0, transform: 'translateY(-100%)', offset: 0}),
          style({opacity: 1, transform: 'translateY(+5%)', offset: 0.8}),
          style({transform: 'translateY(0)', offset: 1})
        ]))
      ]),
    ]),
    trigger('bounceInFromBottom', [
      transition(':enter', [
        animate('500ms ease-out', keyframes([
          style({opacity: 0, transform: 'translateY(100%)', offset: 0}),
          style({opacity: 1, transform: 'translateY(+5%)', offset: 0.8}),
          style({transform: 'translateY(0)', offset: 1})
        ]))
      ]),
    ])
  ]
})
export class AppComponent {
}
