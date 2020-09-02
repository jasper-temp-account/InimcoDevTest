import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private _baseUrl = 'http://localhost:56317/api';

  constructor(private http: HttpClient) {

  }

  reverseName(name: string) {
    return this.http.get(`${this._baseUrl}/reverse/${name}`, {responseType: 'text'});
  }

  consonantCount(name: string) {
    return this.http.get(`${this._baseUrl}/consonants/${name}`, {responseType: 'text'});
  }

  vowelCount(name: string) {
    return this.http.get(`${this._baseUrl}/vowels/${name}`, {responseType: 'text'});
  }
}
