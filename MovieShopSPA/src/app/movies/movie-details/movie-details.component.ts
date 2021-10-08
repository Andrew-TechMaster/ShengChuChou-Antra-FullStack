import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from './../../shared/models/movie';
import { MovieService } from './../../core/services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css'],
})
export class MovieDetailsComponent implements OnInit {
  id: number = 0;
  movieDetails!: Movie;

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService
  ) {}

  ngOnInit(): void {
    // get the id from the URL
    // read the id from URL and go to MovieService , create getMovieDetails method => return Observable<Movie>
    this.route.paramMap.subscribe((p) => {
      this.id = Number(p.get('id'));
      console.log('Movie Id from the URL: ' + this.id);
    });

    // call the Movie Service to get the movie details info
    this.movieService.getMovieDetails(this.id).subscribe((m) => {
      this.movieDetails = m;
      console.log('inside home component inint method');
      console.table(this.movieDetails);
    });
  }
}
