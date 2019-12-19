import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../shared/services/authentication.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.scss']
})
export class AdminLoginComponent implements OnInit {
  logInError: string;
  userForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  logIn() {
    const userFormFields = this.userForm.value;
    if (userFormFields.username && userFormFields.password)
    {
      this.authenticationService.login(userFormFields.username, userFormFields.password)
      .subscribe(
        success => {
          this.router.navigate(['admin/products']);
        },
        error => {
          this.logInError = "User does not exist!";
        });   

    }
    if (!userFormFields.password){
      this.logInError = "Password is required";
    }
    if (!userFormFields.username){
      this.logInError = "Username is required";
    }
  }
}
