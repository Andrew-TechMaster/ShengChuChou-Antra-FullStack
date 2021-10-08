import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieCard } from './../../shared/models/movieCard';
import { Movie } from './../../shared/models/movie';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment'; // import {environment} object from 'src/environments/environment' to get apiUrl

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  // Dependency Injection HttpClient
  // C# int x
  // TS x: int
  constructor(private http: HttpClient) {}

  // Home Component will call this method =>
  getTopGrossingMovies(): Observable<MovieCard[]> {
    // call our API to get list of top movies
    // use HttpClient to make Http Get
    return this.http.get<MovieCard[]>(`${environment.apiUrl}movies/toprevenue`);
    // Angular Services always return Observable<Object> => So we convert JSON data from the API to Observable<TypeScriptModels> and then return
    // HttpClient's method will return Observable<Object>

    // way 2 for conversion/mapping: use map operator from rxjs
    // return this.http
    //   .get('https://localhost:5001/api/Movies/toprevenue')
    //   .pipe(map((resp) => resp as MovieCard[]));

    // rxjs(TS) is like LINQ(C#)
    // map in JS RXJS => Select
    // Filter in JS RXJS => Where
  }

  getMovieDetails(id: number): Observable<Movie> {
    // call API methods that returns movie details
    return this.http.get<Movie>(`${environment.apiUrl}Movies/${id}`);
  }
}
