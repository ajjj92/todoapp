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

  newTodo: { title: string, content: string } = {title: '', content: ''};
  todoItems: TodoItem [] = [];

  constructor(private todoService: TodoItemService) {
  }

  ngOnInit(): void {
    this.fetchTodoItems();
  }

  fetchTodoItems(): void {
    this.todoService.getAll().pipe(first()).subscribe(result => {
      this.todoItems = result;
      console.log(this.todoItems);
    });
  }

  handleStatusChange(todoItem: TodoItem) {
    console.log(todoItem);
    this.todoService.updateStatusById(todoItem.id, todoItem.finished).pipe(first()).subscribe(result => {
      this.fetchTodoItems();
    });
  }

  handleDelete(todoItem: TodoItem) {
    console.log(todoItem);
    this.todoService.deleteById(todoItem.id).pipe(first()).subscribe(result => {
      this.fetchTodoItems();
    });
  }

  onSubmit(newData: any) {
    this.todoService.create(newData.title, newData.content).pipe(first()).subscribe(result => {
      this.fetchTodoItems();
      this.newTodo = {title:'', content:''}
    })
  }
}
