import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthResponse } from 'src/app/models/auth-response.model';
import { Login } from 'src/app/models/login.model';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin!: boolean;
  credentials: Login = { username: '', password: '' };
  login: Login;

  constructor(
    private router: Router,
    private service: LoginService
  ) { }

  ngOnInit(): void {
  }

  connexion = (form: NgForm) => {
    if(form.valid){
      this.service.login(this.credentials)
      .subscribe({
        next: (res: AuthResponse) => {
          console.log(res);
          const token = res.token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
          this.router.navigate(["/"])
        },
        error: (err: HttpErrorResponse) => console.log(err)
      })
    }
  }
}
