import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.scss']
})
export class AdminLoginComponent implements OnInit {

  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor() { }

  ngOnInit() {
  }

}
