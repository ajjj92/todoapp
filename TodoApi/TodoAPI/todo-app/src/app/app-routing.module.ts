import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TodoItemListComponent} from './todo-item-list/todo-item-list.component';

const routes: Routes = [  { path: 'todolist', component: TodoItemListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
