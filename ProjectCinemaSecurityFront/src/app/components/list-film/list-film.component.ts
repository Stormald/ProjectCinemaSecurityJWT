import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Film } from 'src/app/models/film.model';
import { FilmService } from 'src/app/services/film.service';

@Component({
  selector: 'app-list-film',
  templateUrl: './list-film.component.html',
  styleUrls: ['./list-film.component.css']
})
export class ListFilmComponent implements OnInit {

  films;

  constructor(private router: Router, private service: FilmService) { 
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    }
  }

  ngOnInit(): void {
    this.loadFilms();
  }

  loadFilms(): void{
    this.service.getAllFilms().subscribe((data: any) =>{
      this.films = data;
      console.log(this.films);
    })
  }
}
