import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Frame } from '../_models/frame';

@Injectable({
  providedIn: 'root',
})
export class FrameService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getFrames(): Observable<Frame[]> {
    return this.http.get<Frame[]>(this.baseUrl + 'frames');
  }

  getFrame(id: number): Observable<Frame> {
    return this.http.get<Frame>(this.baseUrl + 'frames/' + id);
  }
}
