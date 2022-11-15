import {Component, OnInit} from '@angular/core';
import {TodoItemService} from './todo-item.service';
import {TodoItem} from '../models/todoitem';
import {first} from 'rxjs';

@Component({
  selector: 'app-todo-item-list',
  templateUrl: './todo-item-list.component.html',
  styleUrls: ['./todo-item-list.component.less']
})
export class TodoItemListComponent implements OnInit {

  todoItems: TodoItem [] = [];

  constructor(private todoService: TodoItemService) {
  }

  ngOnInit(): void {
    this.todoService.getAll().pipe(first()).subscribe(result => {
        this.todoItems = result;
        console.log(result);
    });
    this.todoService.test().pipe(first()).subscribe(result => {
      console.log(result);
    });
  }
  handleStatusChange(todoItem:any) {
    console.log(todoItem)
  }
}
