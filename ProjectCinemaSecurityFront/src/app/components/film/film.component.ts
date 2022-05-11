import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Film } from 'src/app/models/film.model';
import { FilmService } from 'src/app/services/film.service';

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css']
})
export class FilmComponent implements OnInit {

idFilm: number;
currentFilm: Film;
reviewForm: FormGroup;
  constructor(private route: ActivatedRoute, private service: FilmService) { 
    this.idFilm = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    console.log(this.idFilm);
    this.service.getFilmById(this.idFilm).subscribe((data:any) => {
      this.currentFilm = data;
    })
  }

  addReview(): void{

  }

}
