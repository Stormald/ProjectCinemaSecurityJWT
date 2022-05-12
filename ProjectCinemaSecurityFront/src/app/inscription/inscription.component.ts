import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../models/login.model';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-inscription',
  templateUrl: './inscription.component.html',
  styleUrls: ['./inscription.component.css']
})
export class InscriptionComponent implements OnInit {

  user: Login = { username: '', password: '' , token: ''};

  constructor(
    private router: Router,
    private service: LoginService
  ) { }

  ngOnInit(): void {
  }

  inscription = (form: NgForm) => {
    if(form.valid){
      this.service.addUser(this.user)
      .subscribe({
        next: (res: Login) => {
          this.user = res;
          this.router.navigate(["/login"]);
        },
        error: (err: HttpErrorResponse) => console.log(err)
        
      })
    }
  }

}
