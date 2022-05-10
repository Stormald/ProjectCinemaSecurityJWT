import { Component, OnInit } from '@angular/core';
import { Film } from 'src/app/models/film.model';
import { FilmService } from 'src/app/services/film.service';

@Component({
  selector: 'app-list-film',
  templateUrl: './list-film.component.html',
  styleUrls: ['./list-film.component.css']
})
export class ListFilmComponent implements OnInit {

  films : Array<Film> = [];

  constructor(private service: FilmService) { }

  ngOnInit(): void {
    this.loadFilms();
  }

  loadFilms(): void{
    this.service.getAllFilms().subscribe((data: any) =>{
      this.films = data;
    })
  }

}
