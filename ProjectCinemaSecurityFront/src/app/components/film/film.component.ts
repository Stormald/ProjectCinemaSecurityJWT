import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Film } from 'src/app/models/film.model';
import { Review } from 'src/app/models/review.model';
import { FilmService } from 'src/app/services/film.service';
import { ReviewService } from 'src/app/services/review.service';

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
    let user = JSON.parse(sessionStorage.getItem('JWT'));
    if (user != null || true) {
      let review = new Review();
      review.score = this.reviewForm.get("scoreControl").value;
      review.text = this.reviewForm.get("textControl").value;
      //review.loginModelId = user.id;
      review.loginModelId = 2;
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

}
