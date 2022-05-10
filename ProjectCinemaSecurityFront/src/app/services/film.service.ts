import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Film } from '../models/film.model';

@Injectable({
  providedIn: 'root'
})
export class FilmService {

  constructor(private http: HttpClient) { }

  getFilmById(id: number) : Observable<Film> {
    return this.http.get<Film>(`${environment.apiUrl}/Film/${id}`);
  }

  getAllFilms() {
    return this.http.get<Film[]>(`${environment.apiUrl}/Film`);
  }

  addFilm(Film: Film) {
    return this.http.post(`${environment.apiUrl}/Film`, Film);
  }

  updateFilm(Film: Film) {
    return this.http.put(`${environment.apiUrl}/Film`, Film);
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/Film/${id}`);
  }
}
