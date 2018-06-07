import { Component, OnInit } from '@angular/core';
import { UploadEvent, FileSystemFileEntry } from 'ngx-file-drop';
import { trigger, state, style, animate, transition, keyframes } from '@angular/animations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('fadeOut', [
      transition(':leave', [
        animate('500ms ease-out', keyframes([
          style({opacity: 1, offset: 0}),
          style({opacity: 0, offset: 1})
        ]))
      ])
    ]),
    trigger('fadeIn', [
      transition(':enter', [
        animate('1000ms ease-in', keyframes([
          style({opacity: 0, offset: 0}),
          style({opacity: 0, offset: 0.5}),
          style({opacity: 1, offset: 1})
        ]))
      ])
    ])
  ]
})
export class HomeComponent implements OnInit {

  public imgFile: string;
  public isFileUploaded = false;

  constructor() { }

  ngOnInit() {
  }

  triggerFileInput() {
    document.getElementById('upload-input').click();
  }

  dragAndDropFile(event: UploadEvent) {
    const self = this;
    if (event.files.length > 1) {
      // TODO: trigger some error
    }
    const file = event.files[0];
    if (file.fileEntry.isFile) {
      const fileEntry = file.fileEntry as FileSystemFileEntry;
      fileEntry.file(function(f) { self.readFile(f); });
    } else {
      // TODO: throw some error
    }
  }

  clickUploadFile(event) {
    this.readFile(event.srcElement.files[0]);
  }

  readFile(file) {
    const self = this;
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function() {
      self.imgFile = reader.result;
      self.isFileUploaded = true;
    };
    reader.onerror = function() {
      console.log(reader.error);
    };
  }
}
