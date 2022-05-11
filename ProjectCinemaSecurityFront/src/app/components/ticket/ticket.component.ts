import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Film } from 'src/app/models/film.model';
import { FilmService } from 'src/app/services/film.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  idFilm: number;
  currentFilm: Film;

  constructor(private route: ActivatedRoute, private service: FilmService) {
    this.idFilm = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    console.log(this.idFilm);
    this.service.getFilmById(this.idFilm).subscribe((data: any) => {
      this.currentFilm = data;
    })
  }

}
