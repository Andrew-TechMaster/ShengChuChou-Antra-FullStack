import { MovieCard } from './../shared/models/movieCard';
import { MovieService } from './../core/services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  movieCards!: MovieCard[];

  constructor(private movieService: MovieService) {} // C#: Inject Service in Controller  // TS: Inject Service in Component

  ngOnInit(): void {
    // console.log('inside home component begin');
    this.movieService.getTopGrossingMovies().subscribe((m) => {
      this.movieCards = m;
      console.log('inside home component inint method');
      console.table(this.movieCards);
    });
  }
}
