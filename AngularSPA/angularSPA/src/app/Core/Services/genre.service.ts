import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Genre } from 'src/app/Shared/Models/Genre';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private httpClient: HttpClient) { }

  getAllGenres():Observable<Genre[]>{
    return this.httpClient.get<Genre[]>("https://movieshopapi.azurewebsites.net/api/Genres");
  }

  addGenre(genre:Genre){
    return this.httpClient.post("https://localhost:7079/api/Genres/add", genre);
  }

  deleteGenre(id:number){
    return true;
  }

}
