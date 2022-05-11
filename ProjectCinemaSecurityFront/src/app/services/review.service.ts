import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review.model';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient) { }

  getReviewById(id: number): Observable<Review> {
    return this.http.get<Review>(`${environment.apiUrl}/Review/${id}`);
  }

  getReviewsByIdFilm(idFilm: number) {
    return this.http.get<Review[]>(`${environment.apiUrl}/Review/Film/${idFilm}`);
  }

  getAllReviews() {
    return this.http.get<Review[]>(`${environment.apiUrl}/Review`);
  }

  addReview(Review: Review) {
    return this.http.post(`${environment.apiUrl}/Review`, Review);
  }

  updateReview(Review: Review) {
    return this.http.put(`${environment.apiUrl}/Review`, Review);
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/Review/${id}`);
  }
}
