import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  logIn() {
    console.log(this.model);
  }

}
