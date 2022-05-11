import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Film } from 'src/app/models/film.model';
import { Review } from 'src/app/models/review.model';
import { FilmService } from 'src/app/services/film.service';
import { ReviewService } from 'src/app/services/review.service';
import decode from 'jwt-decode';


@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css']
})
export class FilmComponent implements OnInit {

idFilm: any;
currentFilm: Film;
reviews: Array<Review>;
reviewForm: FormGroup;
jwtHelper = new JwtHelperService();
  constructor(private route: ActivatedRoute, private service: FilmService, private reviewService: ReviewService) { 
    this.idFilm = this.route.snapshot.params["id"];
    this.reviewForm = new FormGroup({
      scoreControl: new FormControl(null, Validators.required),
      textControl: new FormControl(null, Validators.required)
    });
  }

  ngOnInit(): void {
    
    this.loadFilm();
    this.loadReviews();
  }

  loadFilm(): void {
    this.service.getFilmById(this.idFilm).subscribe((data:any) => {
      this.currentFilm = data;
    })
  }

  loadReviews(): void {
    this.reviewService.getReviewsByIdFilm(this.idFilm).subscribe((data:any) => {
      this.reviews = data;
    })
  }

  addReview(): void {
    if (this.isUserAuthenticated()) {
      let review = new Review();
      review.score = this.reviewForm.get("scoreControl").value;
      review.text = this.reviewForm.get("textControl").value;
      review.loginModelId = parseInt(localStorage.getItem("userId"));
      review.filmModelId = parseInt(this.idFilm);

      console.log(review);

      this.reviewService.addReview(review).subscribe((data: any) => {
        this.loadReviews();
      });

      this.reviewForm.reset();
    }
    else {
      alert("Tu dois être connecté avec un JWT valide.");
    }
  }

  //http://schemas.microsoft.com/ws/2008/06/identity/claims/role

  isAdminAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    const tokenPayload: Object = decode(token);
    let role = "";
    //console.log(tokenPayload);
    for (const [key, value] of Object.entries(tokenPayload)) {
      //console.log(`${key}: ${value}`);
      if(key == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"){
        role = value;
      }
    }
    console.log(role);
    //console.log(Object.entries(tokenPayload).values["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    else {
      return false;
    }
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    const tokenPayload = decode(token);
    console.log(tokenPayload);
    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    else {
      return false;
    }
  }

  supprimerReview = (id: number) => {
    if(this.isAdminAuthenticated()){
      this.reviewService.delete(id).subscribe((data: any) => {
        this.loadReviews();
      });
    }
    
  }

}
