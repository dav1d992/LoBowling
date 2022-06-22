import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../_models/game';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.baseUrl + 'bowlinggames');
  }

  getGame(id: string): Observable<Game> {
    return this.http.get<Game>(this.baseUrl + 'bowlinggames/' + id);
  }
}
