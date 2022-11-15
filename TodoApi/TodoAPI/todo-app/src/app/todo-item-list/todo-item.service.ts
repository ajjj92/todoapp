import { Injectable } from '@angular/core';
import {TodoItem} from '../models/todoitem';
import {HttpClient} from '@angular/common/http';
import {of} from 'rxjs';

const mockData : TodoItem [] = [ {
  id:"guid",
  created:new Date(),
  modified:new Date(),
  modifier:"foo",
  title:"bar",
  content:"foobarz",
  finished:true,
},
  {
    id:"guid2222",
    created:new Date(),
    modified:new Date(),
    modifier:"foozzzz",
    title:"barzzzzz",
    content:"foobarzzzzzzzz",
    finished:false,
  },
]

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {
  baseUrl = "https://localhost:7085"
  apiUrl = this.baseUrl+"TodoItem"
  constructor( private http: HttpClient) { }

  getAll() {
    // return this.http.get<TodoItem[]>(this.apiUrl);
    return of(mockData)
  }
  test() {
    return this.http.get<any>(this.baseUrl + "/WeatherForecast")
  }
}
